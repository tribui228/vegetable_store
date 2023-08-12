

using System;
using System.Collections.Generic;
using Web_market.Models;
namespace Web_market.ModelViews    
{
    public class HomeViewVM
    {
        public List<TinDang> TinTucs { get; set; }
        public List<ProductHomeVM> Products { get; set; }
        public QuangCao quangcao { get; set; }  
    }
}
