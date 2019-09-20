using DBEntityModule.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBEntityModule.Test
{
    public class StudentTest : IEntity<string>
    {
        [Required]
        [Display(Name ="姓名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "性别")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "年龄")]
        public int Age { get; set; }
    }
}
