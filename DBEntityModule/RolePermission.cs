//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace DBEntityModule
//{
//    /// <summary>
//    /// yilezhu
//    /// 2019-03-07 16:50:56
//    /// 角色权限表
//    /// </summary>
//    public partial class RolePermission
//    {
//        /// <summary>
//        /// 主键
//        /// </summary>
//        [Key]
//        public int Id { get; set; }

//        /// <summary>
//        /// 角色主键
//        /// </summary>
//        [Required]
//        [MaxLength(10)]
//        public int RoleId { get; set; }

//        /// <summary>
//        /// 菜单主键
//        /// </summary>
//        [Required]
//        [MaxLength(10)]
//        public int MenuId { get; set; }

//        /// <summary>
//        /// 操作类型（功能权限）
//        /// </summary>
//        [MaxLength(128)]
//        public string Permission { get; set; }


//    }
//}
