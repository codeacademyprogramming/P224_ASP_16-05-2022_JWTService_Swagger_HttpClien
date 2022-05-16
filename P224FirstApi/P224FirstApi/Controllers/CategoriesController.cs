using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P224FirstApi.DAL;
using P224FirstApi.DAL.Entities;
using P224FirstApi.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.Controllers
{
    /// <summary>
    /// Kategoriyaya Aid Servisler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Memmber,SuperAdmin")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CategoriesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Kategoriya Yratmaq Ucun Servis
        /// </summary>
        /// <param name="categoryPostDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CategoryPostDto categoryPostDto)
        {
            Category category = _mapper.Map<Category>(categoryPostDto);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, categoryPostDto);
        }

        /// <summary>
        /// Id-sine Kategoriyanin Tapilmasi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Categories.Include(c=>c.Products).FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return Ok(categoryGetDto);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = await _context.Categories.Include(c=>c.Products).Where(c => !c.IsDeleted).ToListAsync();

            List<CategoryListDto> categoryListDtos = _mapper.Map<List<CategoryListDto>>(categories);

            return Ok(categoryListDtos);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> Put(int? id, CategoryPutDto categoryPutDto)
        {
            if (id == null) return BadRequest();

            if (id != categoryPutDto.Id) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == id);

            if (category == null) return NotFound();

            category.Name = categoryPutDto.Name;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
