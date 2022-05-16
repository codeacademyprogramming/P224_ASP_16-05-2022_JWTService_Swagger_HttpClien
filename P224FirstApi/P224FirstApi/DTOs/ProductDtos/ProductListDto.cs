using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.DTOs.ProductDtos
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string MehsulunAdi { get; set; }
        public double MehsulunQiymeti { get; set; }
    }
}
