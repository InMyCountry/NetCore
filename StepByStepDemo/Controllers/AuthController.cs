using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigureExtensionsModule.SwaggerExtension.JwtModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StepByStepDemo.Controllers
{
    /// <summary>
    /// 授权控制器
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Jwt获取授权码
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult GetJwtToken([FromBody] JwtToken jwtToken)
        {
            string Token = JwtTokenHelp.GetJWT(jwtToken);
            return Content(Token);
        }
        /// <summary>
        /// Jwt测试授权
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public DateTime JwtAuthorizeTest()
        {
            return DateTime.Now;
        }
    }
}