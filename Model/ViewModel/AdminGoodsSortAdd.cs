using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.ViewModel
{
    public class AdminGoodsSortAdd
    {
        [Required]
        public string GoodsSortName { get; set; }
    }
}
