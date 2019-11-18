using Project_SEM2_HNDShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SEM2_HNDShop.DTO
{
    public class ItemIndex
    {
        public List<SubBrand> listsb { get; set; }
        public List<Promotion> listpromo { get; set; }
        public List<Category> listcate { get; set; }
        public List<ProductDto> listproductDtos { get; set; }
    }
}
