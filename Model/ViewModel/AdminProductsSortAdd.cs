using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Model.ViewModel
{
    public class AdminProductsSortAdd
    {
        [Required(ErrorMessage="提交的产品分类必填")]
        public string ProductsSortName { get; set; }
        public string ProductsSortLogo { get; set; }
        public string ProductsSortBrife { get; set; }
        public string ProductsSortWeb { get; set; }
    }
}
