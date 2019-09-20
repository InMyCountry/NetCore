using DBEntityModule;
using DBEntityModule.Test;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkModule
{
    public class StepByStepDbContext:DbContext
    {
        public StepByStepDbContext(DbContextOptions<StepByStepDbContext> dbContextOptions):base(dbContextOptions)
        {
        }
        /// <summary>
        /// 测试用的
        /// </summary>
        public DbSet<StudentTest> StudentTests { get; set; }
        /// <summary>
        /// 系统用户表
        /// </summary>
        //public DbSet<Student>  Students { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        /// <summary>
        /// 系统角色表
        /// </summary>
        public DbSet<SystemRole> SystemRoles { get; set; }
        /// <summary>
        /// 用户角色关联表
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }
        /// <summary>
        /// 菜单表
        /// </summary>
        public DbSet<SystemMenu>  SystemMenus { get; set; }
        /// <summary>
        /// 角色菜单关联表
        /// </summary>
        public DbSet<RoleMenu>   RoleMenus { get; set; }
    }
}
