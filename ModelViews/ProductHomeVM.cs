using System;
using System.Collections.Generic;
using Web_market.Models;
namespace Web_market.ModelViews

{
    public class ProductHomeVM
    {
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }
    }   
}
