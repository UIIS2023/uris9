﻿using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Gateway.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Gateway.Models.Parcela;
using Gateway.Logger;
using Google.Cloud.Logging.Type;
using System.Reflection;

namespace Gateway.Controllers.Parcela
{
    [Route("api/parcela")]
    [ApiController]
    [Produces("application/json")]
    public class ParcelaController : ControllerBase
    {
        private readonly IServiceCall<ParcelaDto, ParcelaDto> _serviceCall;
        private readonly string url = $"{StaticDetails.ParcelaService}api/parcela/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public ParcelaController(IServiceCall<ParcelaDto, ParcelaDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Superuser")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<ParcelaDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var parcele = _serviceCall.GetAsync(url).Result;
                if (parcele == null)
                {
                    _error = $"Ne postoji nijedna parcela";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(parcele);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Superuser")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ParcelaDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var parcela = _serviceCall.GetByIdAsync(url, id).Result;
                if (parcela == null)
                {
                    _error = $"Ne postoji parcela sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(parcela);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Superuser")]
        [HttpPost]
        public ActionResult<ParcelaDto> Post(ParcelaDto parcelaDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var parcela = _serviceCall.PostAsync(url, parcelaDto).Result;
                if (parcela == null)
                {
                    _error = $"Postoji parcela {parcelaDto.BrojParcele}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(409, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(parcela);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Superuser")]
        [HttpPut("{id}")]
        public ActionResult<ParcelaDto> Put(int id, ParcelaDto parcelaDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var parcela = _serviceCall.PutAsync(url, id, parcelaDto).Result;
                if (parcela == null)
                {
                    _error = $"Vec postoji parcela {parcelaDto.BrojParcele} ili ne postoji parcela sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(parcela);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Superuser")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var parcela = _serviceCall.DeleteAsync(url, id).Result;
                if (parcela == null)
                {
                    _error = $"Ne postoji parcela sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(parcela);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
