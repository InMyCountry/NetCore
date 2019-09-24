using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.IServices.IServices;
using DBEntityModule.Test;
using Microsoft.Extensions.Logging;
using DBEntityModule;

namespace StepByStepDemo.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SystemMenuController : ControllerBase
    {
        private readonly ISystemMenuService _systemMenuService;
        private readonly IRoleMenuService  _roleMenuService;
        private readonly ISystemRoleService  _systemRoleService;
        private readonly IUnitOfWork  _unitOfWork;
        private readonly ILogger<StudentTestController> _logger;

        public SystemMenuController(ISystemMenuService systemMenuService, IRoleMenuService roleMenuService, ISystemRoleService systemRoleService, IUnitOfWork unitOfWork, ILogger<StudentTestController> logger)
        {

            _systemMenuService = systemMenuService;
            _roleMenuService = roleMenuService;
            _systemRoleService = systemRoleService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        /// <summary>
        /// 菜单添加
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddMenu()
        {
            try
            {
                List<SystemMenu> systemMenus = new List<SystemMenu>();
                SystemMenu systemMenu = null;
                for (int i = 1; i <= 5; i++)
                {
                    systemMenu = new SystemMenu()
                    {
                        Id = Guid.NewGuid().ToString(),
                        AddTime = DateTime.Now,
                        DisplayName = "菜单测试" + i,
                        IconUrl = string.Empty,
                        IsDelete = false,
                        IsDisplay = true,
                        IsSystem = true,
                        LinkUrl = string.Empty,
                        Name = "菜单" + i,
                        Sort = i
                    };
                    systemMenus.Add(systemMenu);
                }
                _systemMenuService.AddAll(systemMenus);
                SystemRole systemRole = new SystemRole
                {
                    Id = Guid.NewGuid().ToString(),
                    AddTime = DateTime.Now,
                    IsDelete = false,
                    IsSystem = true,
                    RoleName = "超级管理员",
                    RoleType = 1,
                    Remark = "测试使用"
                };
                _systemRoleService.Add(systemRole);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleMenu()
        {
            try
            {
                _roleMenuService.GetAll();
                var menus = _systemMenuService.GetAll();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 菜单关联
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RoleRelateMenu()
        {
            try
            {
                var menus = _systemMenuService.GetAll();
                var role = _systemRoleService.GetAll().FirstOrDefault();
                RoleMenu roleMenu = null; 
                foreach (var item in menus)
                {
                    roleMenu = new RoleMenu()
                    {
                        Id = Guid.NewGuid().ToString(),
                        AddTime = DateTime.Now,
                        IsDelete = false,
                        SystemMenus = item,
                        SystemRoles = role
                    };
                    _roleMenuService.Add(roleMenu);
                }
                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}