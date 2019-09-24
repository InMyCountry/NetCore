using DBEntityModule;
using EntityFrameworkModule;
using Repository.IServices.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services.Services
{
    public class SystemRoleService : RepositoryBase<SystemRole,string>, ISystemRoleService
    {
        private readonly StepByStepDbContext _aspNetCoreDbContext;
        public SystemRoleService(StepByStepDbContext aspNetCoreDbContext) : base(aspNetCoreDbContext)
        {
            _aspNetCoreDbContext = aspNetCoreDbContext;
        }
    }
}
