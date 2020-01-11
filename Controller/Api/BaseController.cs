using LuciaTech.Helper.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuciaTech.Helper.Controller.Api
{
    [Produces("application/json")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ObjectResult AppError(Exception ex)
        {
            try
            {
                if (ex is HttpException)
                {
                    var _exception = (HttpException)ex;
                    return StatusCode(_exception.StatusCode, new ApiResponse<bool>().BadRequest(false, _exception.Message));
                }
                return StatusCode(500, new ApiResponse<bool>().BadRequest(false, ex.Message));
            }
            catch
            {
                return StatusCode(500, new ApiResponse<bool>().BadRequest(false, ex.Message));
            }

        }
    }
}
