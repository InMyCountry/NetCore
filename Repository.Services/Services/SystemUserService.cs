using DBEntityModule;
using EntityFrameworkModule;
using Repository.IServices.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services.Services
{
    public class SystemUserService : RepositoryBase<SystemUser,string>, ISystemUserService
    {
        private readonly StepByStepDbContext _aspNetCoreDbContext;
        public SystemUserService(StepByStepDbContext aspNetCoreDbContext) : base(aspNetCoreDbContext)
        {
            _aspNetCoreDbContext = aspNetCoreDbContext;
        }
    }
}
