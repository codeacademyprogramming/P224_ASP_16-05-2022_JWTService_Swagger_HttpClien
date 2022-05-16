using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P224FirstApi.DAL;
using P224FirstApi.DAL.Entities;
using P224FirstApi.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="SuperAdmin")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Product Yaranmasi Ucun Service
        /// </summary>
        /// <param name="productPostDto"></param>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST api/Products
        ///     {
        ///         "mehsulunAdi": "Telefom",
        ///         "mehsulunQiymeti":3500,
        ///         "mehsulunEndirimQiymeti":3000
        ///     }
        /// </remarks>
        /// <response code="201">Her Sey Eladi</response>
        /// <response code="404">Gonderilen Id-li Obyek Tapilmadi</response>
        /// <response code="400">Root-da Id Gonderilmiyib</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(ProductPostDto productPostDto)
        {
            Product product = new Product();
            product.Name = productPostDto.MehsulunAdi;
            product.Price = productPostDto.MehsulunQiymeti;
            product.DiscountPrice = productPostDto.MehsulunEndirimQiymeti;
            product.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, product);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //List<ProductListDto> productListDtos = await _context.Products.Where(p => !p.IsDeleted)
            //    .Select(x => new ProductListDto
            //    {
            //        Id = x.Id,
            //        MehsulunAdi = x.Name,
            //        MehsulunQiymeti = x.Price
            //    }).ToListAsync();

            List<Product> products = await _context.Products.Where(p => !p.IsDeleted).ToListAsync();

            List<ProductListDto> productListDtos = _mapper.Map < List<ProductListDto>>(products);

            return Ok(productListDtos);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p=>p.Category).ThenInclude(c=>c.Products)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            //ProductGetDto productGetDto = new ProductGetDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Price = product.Price,
            //    DiscountPrice = product.DiscountPrice
            //};

            ProductGetDto productGetDto = _mapper.Map<ProductGetDto>(product);

            return Ok(productGetDto);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> Put(int? id, ProductPutDto productPutDto)
        {
            if (id == null) return BadRequest();

            if (id != productPutDto.Id) return BadRequest();

            Product existedproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == productPutDto.Id && !p.IsDeleted);

            if (existedproduct == null) return NotFound();

            existedproduct.Name = productPutDto.MehsulunAdi;
            existedproduct.Price = productPutDto.MehsulunQiymeti;
            existedproduct.UpdatedAt = DateTime.UtcNow.AddHours(4);
            existedproduct.DiscountPrice = productPutDto.MehsulunEndirimQiymeti;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            Product existedproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (existedproduct == null) return NotFound();

            existedproduct.IsDeleted = true;
            existedproduct.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
