using DBEntityModule;
using EntityFrameworkModule;
using Repository.IServices.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services.Services
{
    public class SystemMenuService: RepositoryBase<SystemMenu,string>, ISystemMenuService
    {
        private readonly StepByStepDbContext _aspNetCoreDbContext;
        public SystemMenuService(StepByStepDbContext aspNetCoreDbContext) : base(aspNetCoreDbContext)
        {
            _aspNetCoreDbContext = aspNetCoreDbContext;
        }
    }
}
