using Dapper;
using DapperEmlakProjesiMuratYucedagEgitimi.API.Dtos.CategoryDtos;
using DapperEmlakProjesiMuratYucedagEgitimi.API.Models.DapperContext;
using DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.CategoryRepository.Abstract;

namespace DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.CategoryRepository.Concreate
{
    public class CategoryRepository : ICategoryRepository
    {
        
        private readonly MSSqlServerContext _msSqlServerContex;

        public CategoryRepository(MSSqlServerContext msSqlServerContex)
        {
            
            _msSqlServerContex = msSqlServerContex;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT * FROM CATEGORY";
            using (var connection = _msSqlServerContex.CreateConnection())
            {
                try
                {
                    var values = await connection.QueryAsync<ResultCategoryDto>(query);
                    var result = values.ToList();
                    if (result.Count is not 0)
                    {
                        return result;
                    }
                    else
                    {
                        return new List<ResultCategoryDto>();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
