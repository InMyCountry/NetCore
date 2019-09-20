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
    }
}
