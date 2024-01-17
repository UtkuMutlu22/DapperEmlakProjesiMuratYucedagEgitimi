using DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.CategoryRepository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperEmlakProjesiMuratYucedagEgitimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            try
            {
                var result = await _categoryRepository.GetAllCategoryAsync();
                if (result.Count > 0)
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }
    }
}
