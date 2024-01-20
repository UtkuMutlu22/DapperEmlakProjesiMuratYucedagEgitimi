using DapperEmlakProjesiMuratYucedagEgitimi.API.Dtos.CategoryDtos;
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

        [HttpGet("/GetAllCategoryListAsync")]
        public async Task<IActionResult> GetAllCategoryListAsync()
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

        [HttpGet("/GetCategoryByIdAsync/{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            try
            {
                var result = await _categoryRepository.GetCategoryByIDAsync(id);
                if (result is not null)
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/GetActiveCategoryListAsync")]
        public async Task<IActionResult> GetActiveCategoryListAsync()
        {
            try
            {
                var result = await _categoryRepository.GetActiveCategoryAsync();
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

        [HttpGet("/GetPassiveCategoryListAsync")]
        public async Task<IActionResult> GetPassiveCategoryListAsync()
        {
            try
            {
                var result = await _categoryRepository.GetPassiveCategoryAsync();
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

        [HttpPost("/CreateCategoryAsync")]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var result = await _categoryRepository.CreateCategoryAsync(createCategoryDto);
                if (result)
                    return Ok(new { Message = "Kategori Eklendi" });
                else
                    return BadRequest(new { Message = "Kategori Eklenemedi" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Kategori Eklenemedi HATA: {ex.Message}" });
            }
        }

        [HttpDelete("/DeleteCategoryAsync/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                var response = await _categoryRepository.DeleteCategoryAsync(id);
                if (response)
                {
                    return Ok(new { Message = "Kategory Silindi" });
                }
                else
                {
                    return BadRequest(new { Message = "Kategory Silinemedi" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = $"{ex.Message}" });
            }
        }

        [HttpPut("/UpdateCategoryAsync")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var response = await _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
                if (response)
                {
                    return Ok(new { Message = "Kategory Güncellendi" });
                }
                else
                {
                    return BadRequest(new { Message = "Kategory Güncellenemedi" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = $"Kategory Güncellenemedi. HATA :{ex.Message}" });
            }
        }

        [HttpPatch("/SetPassiveCategoryAsync/{id}")]
        public async Task<IActionResult> SetPassiveCategoryAsync(int id)
        {
            var model = new SetPassiveCategoryDto { CategoryID = id };
            try
            {
                var response = await _categoryRepository.SetPassiveCategoryAsync(model);
                if (response)
                {
                    return Ok(new { Message = "Kategori pasif edildi" });
                }
                else
                {
                    return BadRequest(new { Message = "Kategori pasif edilemedi" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = $"Kategori pasif edilemedi HATA :{ex.Message}" });
            }
        }

        [HttpPatch("/SetActiveCategoryAsync/{id}")]
        public async Task<IActionResult> SetActiveCategoryAsync(int id)
        {
            var model = new SetActiveCategoryDto { CategoryID = id };
            try
            {
                var response = await _categoryRepository.SetActiveCategoryAsync(model);
                if (response)
                {
                    return Ok(new { Message = "Kategori aktif edildi" });
                }
                else
                {
                    return BadRequest(new { Message = "Kategori aktif edilemedi" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = $"Kategori aktif edilemedi HATA :{ex.Message}" });
            }
        }
    }
}
