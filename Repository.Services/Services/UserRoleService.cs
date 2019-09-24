using DBEntityModule;
using EntityFrameworkModule;
using Repository.IServices.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services.Services
{
    public class UserRoleService: RepositoryBase<UserRole,string>, IUserRoleService
    {
        private readonly StepByStepDbContext _aspNetCoreDbContext;
        public UserRoleService(StepByStepDbContext aspNetCoreDbContext) : base(aspNetCoreDbContext)
        {
            _aspNetCoreDbContext = aspNetCoreDbContext;
        }
    }
}
