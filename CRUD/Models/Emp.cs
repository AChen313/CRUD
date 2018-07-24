using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Emp
    {
        [Display(Name = "客戶編號")]
        public string No { get; set; }
        [Display(Name = "客戶名稱")]
        public string Name { get; set; }
        [Display(Name = "年齡")]
        public int Age { get; set; }
        [Display(Name = "性別")]
        public int Sex { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
    }
}
