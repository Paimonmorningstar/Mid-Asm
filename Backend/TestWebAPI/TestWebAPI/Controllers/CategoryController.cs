using System.Net;
using System.ComponentModel;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Data.Entities;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpGet("category")]
        public async Task<IActionResult> GetCategory()
        {
            var result = await _categoryService.Get();
            return Ok(result);
        }

        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var result = await _categoryService.Get(categoryId);

            return Ok(result);
        }

        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPost("category")]
        public HttpStatusCode CreateCategory(Category category)
        {
            _categoryService.CreateCategory(category);
            return HttpStatusCode.OK;
        }


        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPut("updateCategory")]
       public HttpStatusCode UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
            return HttpStatusCode.OK;

        }
        
        [AllowAnonymous]
        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPut("deleteCategory")]

        public HttpStatusCode DeleteCategory(int id, Category category)
        {
            _categoryService.DeleteCategory(id, category);
            return HttpStatusCode.OK;
        }

    }
}


