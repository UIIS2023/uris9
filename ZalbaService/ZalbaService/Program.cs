using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZalbaService.Entities;
using ZalbaService.Repository;
using Microsoft.OpenApi.Models;
using ZalbaService.ServiceCalls;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(setupAction =>
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    //Kreiramo problem details objekat
                    ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                        .GetRequiredService<ProblemDetailsFactory>();

                    //Prosle�ujemo trenutni kontekst i ModelState, ovo prevodi validacione gre�ke iz ModelState-a u RFC format
                    ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                        context.HttpContext,
                        context.ModelState);

                    //Ubacujemo dodatne podatke
                    problemDetails.Detail = "Pogledajte polje errors za detalje.";
                    problemDetails.Instance = context.HttpContext.Request.Path;

                    //po defaultu se sve vra�a kao status 400 BadRequest, to je ok kada nisu u pitanju validacione gre�ke,
                    //ako jesu ho�emo da koristimo status 422 UnprocessibleEntity
                    //tra�imo info koji status kod da koristimo
                    var actionExecutiongContext = context as ActionExecutingContext;

                    //proveravamo da li postoji neka gre�ka u ModelState-u, a tako�e proveravamo da li su svi prosle�eni parametri dobro parsirani
                    //ako je sve ok parsirano ali postoje gre�ke u validaciji ho�emo da vratimo status 422
                    if ((context.ModelState.ErrorCount > 0) &&
                        (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                    {
                        problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                        problemDetails.Title = "Do�lo je do gre�ke prilikom validacije.";

                        //sve vra�amo kao UnprocessibleEntity objekat
                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    }

                    //ukoliko postoji ne�to �to nije moglo da se parsira ho�emo da vra�amo status 400 
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Do�lo je do gre�ke prilikom parsiranja poslatog sadr�aja.";
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddSingleton<IKupacMockRepository, KupacMockRepository>();
builder.Services.AddScoped<IZalbaRepository, ZalbaRepository>();
builder.Services.AddScoped<ITipZalbeRepository, TipZalbeRepository>();
builder.Services.AddScoped<IStatusZalbeRepository, StatusZalbeRepository>();
builder.Services.AddScoped<IRadnjaNaOsnovuZalbeRepository, RadnjaNaOsnovuZalbeRepository>();
builder.Services.AddScoped<IKupacService, KupacService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("v1",
                   new OpenApiInfo()
                   {
                       Title = "�alba API",
                       Version = "v1",
                       Description = "Pomo�u ovog API-ja mo�e da se vr�i dodavanje kako �albe,tako i statusa i tipa,a�uriranje prethodno dodatih �albi,statusa i tipova,pregled i brisanje.",
                       Contact = new OpenApiContact
                       {
                           Name = "Sa�a Ili�",
                           Email = "ilic.sasa2001@gmail.com",
                           Url = new Uri(builder.Configuration["Link:Ftn"])
                       },
                       License = new OpenApiLicense
                       {
                           Name = "FTN licence",
                           Url = new Uri(builder.Configuration["Link:Ftn"])
                       },
                   });
    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    //Pravimo putanju do XML fajla sa komentarima
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

    //Govorimo swagger-u gde se nalazi dati xml fajl sa komentarima
    setupAction.IncludeXmlComments(xmlCommentsPath);
});
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        //Podesavamo endpoint gde Swagger UI moze da pronadje OpenAPI specifikaciju
        setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "�alba API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
