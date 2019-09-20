using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IServices.IServices
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交事务
        /// </summary>
        int Commit();
    }
}
