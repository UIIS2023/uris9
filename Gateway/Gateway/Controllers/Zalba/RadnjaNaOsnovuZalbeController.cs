﻿using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.Zalba;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.Zalba
{
    [Route("api/radnjaNaOsnovuZalbe")]
    [ApiController]
    [Produces("application/json")]
    public class RadnjaNaOsnovuZalbeController  : ControllerBase
    {
        private readonly IServiceCall<RadnjaNaOsnovuZalbeCreationDto, RadnjaNaOsnovuZalbeDto> _serviceCall;
        private readonly string url = $"{StaticDetails.ZalbaService}api/radnjaNaOsnovuZalbe/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public RadnjaNaOsnovuZalbeController(IServiceCall<RadnjaNaOsnovuZalbeCreationDto, RadnjaNaOsnovuZalbeDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Operater nadmetanja")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<RadnjaNaOsnovuZalbeDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var radnjeNaOsnovuZalbe = _serviceCall.GetAsync(url).Result;
                if (radnjeNaOsnovuZalbe == null)
                {
                    _error = $"Ne postoji nijedna radnja na osnovu zalbe";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(radnjeNaOsnovuZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Operater nadmetanja")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RadnjaNaOsnovuZalbeDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var radnjaNaOsnovuZalbe = _serviceCall.GetByIdAsync(url, id).Result;
                if (radnjaNaOsnovuZalbe == null)
                {
                    _error = $"Ne postoji radnja na osnovu zalbe sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(radnjaNaOsnovuZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpPost]
        public ActionResult<RadnjaNaOsnovuZalbeCreationDto> Post(RadnjaNaOsnovuZalbeCreationDto radnjaNaOsnovuZalbeDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var radnjaNaOsnovuZalbe = _serviceCall.PostAsync(url, radnjaNaOsnovuZalbeDto).Result;
                if (radnjaNaOsnovuZalbe == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(radnjaNaOsnovuZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpPut]
        public ActionResult<RadnjaNaOsnovuZalbeDto> Put(int id, RadnjaNaOsnovuZalbeDto radnjaNaOsnovuZalbeDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var radnjaNaOsnovuZalbe = _serviceCall.PutAsync(url, id, radnjaNaOsnovuZalbeDto).Result;
                if (radnjaNaOsnovuZalbe == null)
                {
                    _error = $"Ne postoji radnja na osnovu zalbe sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(radnjaNaOsnovuZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var radnjaNaOsnovuZalbe = _serviceCall.DeleteAsync(url, id).Result;
                if (radnjaNaOsnovuZalbe == null)
                {
                    _error = $"Ne postoji radnja na osnovu zalbe sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(radnjaNaOsnovuZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
