using DBEntityModule.Test;
using EntityFrameworkModule;
using Repository.IServices.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services.Services
{
    public class StudentTestService: RepositoryBase<StudentTest,string>, IStudentTestService
    {
        private readonly StepByStepDbContext _aspNetCoreDbContext;
        public StudentTestService(StepByStepDbContext aspNetCoreDbContext) : base(aspNetCoreDbContext)
        {
            _aspNetCoreDbContext = aspNetCoreDbContext;
        }
    }
}
