using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ViewModel
{
    public class GoodsList
    {
        public int GoodsID { get; set; }
        public string GoodsName { get; set; }
        public string RentPrice { get; set; }
        public string SalePrice { get; set; }

        public int GoodsSortID { get; set; }
        public int ProductsSortID { get; set; }

        public string GoodsPic { get; set; }
        public string GoodsBrife { get; set; }
        public string Features { get; set; }
        public string Specifications { get; set; }
        public string Supplies { get; set; }
    }
}
