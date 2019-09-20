using DBEntityModule.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntityModule
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRole : IEntity<string>
    {
        /// <summary>
        /// 用户
        /// </summary>
        public SystemUser UserAccount { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public SystemRole   SystemRole { get; set; }
      
    }
}
