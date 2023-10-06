using CodePulse.DataAccess.Models;
using CodePulse.DataAccess.Repositories;
using CodePulse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesRepository _catRepo;
        public CategoriesController()
        {
            _catRepo = new CategoriesRepository();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var category = new CategoriesModel
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };
            await _catRepo.CreateCategory(category);
            var result = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };
            return Ok(result);
        }
    }
}
