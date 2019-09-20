using EntityFrameworkModule;
using Repository.IServices.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        /// <summary>
        /// 数据上下文
        /// </summary>
        private StepByStepDbContext _Context;
        public UnitOfWork(StepByStepDbContext Context)
        {
            _Context = Context;
        }


        public int Commit()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            if (_Context != null)
            {
                _Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
