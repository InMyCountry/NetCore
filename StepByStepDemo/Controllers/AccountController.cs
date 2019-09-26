using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBEntityModule;
using Repository.IServices.IServices;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using DBEntityModule.Test;
using StepByStep.Common.Model;
using StepByStep.Common.Helper;

namespace StepByStepDemo.Controllers
{
    /// <summary>
    /// 系统用户管理
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly ISystemUserService _systemUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ISystemUserService systemUserService, IUnitOfWork unitOfWork, ILogger<AccountController> logger)
        {
            _systemUserService = systemUserService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="systemUser"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register([FromBody]SystemUser systemUser)
        {
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(systemUser));
        }
        /// <summary>
        /// 根据用户名密码获取授权码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAccessToken(string userName, string password)
        {
            try
            {
                var user = _systemUserService.Get(f => f.UserName == userName && f.Password == password);
                if (user != null)
                {
                    JwtToken jwtToken = new JwtToken
                    {
                        ID = user.Id,
                        Name = user.UserName
                    };
                    string Token = JwtTokenHelp.GetJWT(jwtToken);
                    return Ok(Token);
                }
                else
                {
                    return Ok("未能找到此用户");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message); 
            }
        }

        [HttpPost]
        public IActionResult AddUserTest()
        {
            try
            {
                SystemUser systemUser = new SystemUser
                {
                    Id = Guid.NewGuid().ToString(),
                    AddTime = DateTime.Now,
                    IsLock = false,
                    IsDelete = false,
                    UserName = "admin",
                    Password = "admin"
                };
                _systemUserService.Add(systemUser);
                _unitOfWork.Commit();
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(systemUser));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}