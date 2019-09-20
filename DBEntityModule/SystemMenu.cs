using DBEntityModule.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBEntityModule
{
   public class SystemMenu : IEntity<string>
    {
        /// <summary>
        /// 父菜单ID
        /// </summary>
        public string ParentMenuId { get; set; }
        public SystemMenu  ParentMenu { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [MaxLength(32)]
        public String Name { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [MaxLength(128)]
        public String DisplayName { get; set; }

        /// <summary>
        /// 图标地址
        /// </summary>
        [MaxLength(128)]
        public String IconUrl { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [MaxLength(128)]
        public String LinkUrl { get; set; }

        /// <summary>
        /// 排序数字
        /// </summary>
        [MaxLength(10)]
        public Int32 Sort { get; set; }

        /// <summary>
        /// 操作权限（按钮权限时使用）
        /// </summary>
        [MaxLength(256)]
        public String Permission { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [Required]
        [MaxLength(1)]
        public Boolean IsDisplay { get; set; }

        /// <summary>
        /// 是否系统默认
        /// </summary>
        [Required]
        [MaxLength(1)]
        public Boolean IsSystem { get; set; }

        public ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
