﻿using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.Zakup;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.Zakup
{
    [Route("api/tipGarancije")]
    [ApiController]
    [Produces("application/json")]
    public class TipGarancijeController : ControllerBase
    {
        private readonly IServiceCall<TipGarancijeDto, TipGarancijeConfirmationDto> _serviceCall;
        private readonly string url = $"{StaticDetails.UgovorService}api/tipGarancije/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public TipGarancijeController(IServiceCall<TipGarancijeDto, TipGarancijeConfirmationDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Tehnicki sekretar")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<TipGarancijeConfirmationDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipoviGarancije = _serviceCall.GetAsync(url).Result;
                if (tipoviGarancije == null)
                {
                    _error = $"Ne postoji nijedan tip garancije";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipoviGarancije);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Tehnicki sekretar")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipGarancijeConfirmationDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipGarancije = _serviceCall.GetByIdAsync(url, id).Result;
                if (tipGarancije == null)
                {
                    _error = $"Ne postoji tip garancije sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipGarancije);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Tehnicki sekretar")]
        [HttpPost]
        public ActionResult<TipGarancijeDto> Post(TipGarancijeDto tipGarancijeDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipGarancije = _serviceCall.PostAsync(url, tipGarancijeDto).Result;
                if (tipGarancije == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipGarancije);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Tehnicki sekretar")]
        [HttpPut]
        public ActionResult<TipGarancijeConfirmationDto> Put(int id, TipGarancijeConfirmationDto tipGarancijeDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipGarancije = _serviceCall.PutAsync(url, id, tipGarancijeDto).Result;
                if (tipGarancije == null)
                {
                    _error = $"Ne postoji tip garancije sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipGarancije);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Tehnicki sekretar")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipGarancije = _serviceCall.DeleteAsync(url, id).Result;
                if (tipGarancije == null)
                {
                    _error = $"Ne postoji tip garancije sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipGarancije);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
