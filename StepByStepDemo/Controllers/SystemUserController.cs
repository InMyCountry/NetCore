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

namespace StepByStepDemo.Controllers
{
    /// <summary>
    /// 系统用户管理
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserService _systemUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SystemUserController> _logger;

        public SystemUserController(ISystemUserService systemUserService, IUnitOfWork unitOfWork, ILogger<SystemUserController> logger)
        {
            _systemUserService = systemUserService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody]SystemUser systemUser)
        {

            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(systemUser));
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