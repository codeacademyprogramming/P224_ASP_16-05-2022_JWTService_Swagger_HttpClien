using P224FirstApi.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.DTOs.ProductDtos
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string MehsulunAdi { get; set; }
        public double MehsulunQiymeti { get; set; }
        public double MehsulunEndirimQiymeti { get; set; }
        public double DiscountPercent { get; set; }
        public CategoryGetDto Category { get; set; }
    }
}
