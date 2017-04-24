using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;


namespace Model.ViewModel
{

    
    public class GoodSort {
        public int GoodsSortID { get; set; }
        public string GoodsSortName { get; set; }
        public List<Good> nodes { get; set; }
    }

    public class ProductsSort
    {
        public int ProductsSortID { get; set; }
        public string ProductsSortName { get; set; }
        public List<GoodSort> nodes { get; set; }
    }
    public  class Good
    {
        public int GoodsID { get; set; }
        public string GoodsName { get; set; }
      
      
    }
   
}
