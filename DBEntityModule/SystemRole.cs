using DBEntityModule.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBEntityModule
{
    /// <summary>
    /// 系统角色
    /// </summary>
    public class SystemRole : IEntity<string>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        [MaxLength(64)]
        public String RoleName { get; set; }

        /// <summary>
        /// 角色类型1超管2系管
        /// </summary>
        [Required]
        [MaxLength(10)]
        public Int32 RoleType { get; set; }

        /// <summary>
        /// 是否系统默认
        /// </summary>
        [Required]
        [MaxLength(1)]
        public Boolean IsSystem { get; set; }
        /// <summary>
        /// 用户角色关联表
        /// </summary>
        public ICollection<UserRole> UserRoles { get; set; }
        /// <summary>
        /// 角色菜单关联表
        /// </summary>
        public ICollection<RoleMenu> RoleMenus { get; set; }

    }
}
