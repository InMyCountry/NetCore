using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBEntityModule.BaseEntity
{
    public abstract class IEntity<T>
    {
        [Display(Name ="唯一标识")]
        [Key]
        public virtual T Id { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        [MaxLength(1)]
        public virtual Boolean IsDelete { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(128)]
        public virtual String Remark { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Required]
        [MaxLength(23)]
        public DateTime AddTime { get; set; }
    }
}
