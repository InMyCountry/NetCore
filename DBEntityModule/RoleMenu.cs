using DBEntityModule.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntityModule
{
    public class RoleMenu : IEntity<string>
    {
        public SystemMenu SystemMenus { get; set; }
        public SystemRole  SystemRoles { get; set; }
    }
}
