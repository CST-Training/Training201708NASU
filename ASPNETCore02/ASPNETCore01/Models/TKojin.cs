using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCore01.Models
{
    public partial class TKojin
    {
        public int Id { get; set; }
        [Display(Name ="氏名")]
        public string ENamae { get; set; }
        [Display(Name = "年齢")]
        public short ENenrei { get; set; }
       
        public int ESeibetsu { get; set; }
        [Display(Name = "性別")]
        public virtual TSeibetsu ESeibetsuNavigation { get; set; }
    }
}
