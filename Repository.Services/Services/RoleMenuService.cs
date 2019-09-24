using DBEntityModule;
using EntityFrameworkModule;
using Repository.IServices.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services.Services
{
    public class RoleMenuService : RepositoryBase<RoleMenu,string>, IRoleMenuService
    {
        private readonly StepByStepDbContext _aspNetCoreDbContext;
        public RoleMenuService(StepByStepDbContext aspNetCoreDbContext) : base(aspNetCoreDbContext)
        {
            _aspNetCoreDbContext = aspNetCoreDbContext;
        }
    }
}
