using DBEntityModule.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBEntityModule
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class SystemUser : IEntity<string>
    {
       

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public String UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(128)]
        public String Password { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(256)]
        public String Avatar { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [MaxLength(32)]
        public String NickName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [MaxLength(16)]
        public String Mobile { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [MaxLength(128)]
        public String Email { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        [MaxLength(10)]
        public Int32 LoginCount { get; set; } = 0;

        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        [MaxLength(64)]
        public String LoginLastIp { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        [MaxLength(23)]
        public DateTime LoginLastTime { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        [Required]
        [MaxLength(1)]
        public Boolean IsLock { get; set; }

        /// <summary>
        ///  用户角色多对多
        /// </summary>
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
