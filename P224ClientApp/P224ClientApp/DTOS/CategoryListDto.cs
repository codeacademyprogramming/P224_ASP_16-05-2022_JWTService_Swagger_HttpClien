using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224ClientApp.DTOS
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductsCount { get; set; }
    }
}
