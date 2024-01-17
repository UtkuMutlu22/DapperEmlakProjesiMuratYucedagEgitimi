using Dapper;
using DapperEmlakProjesiMuratYucedagEgitimi.API.Dtos.CategoryDtos;
using DapperEmlakProjesiMuratYucedagEgitimi.API.Models.DapperContext;
using DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.CategoryRepository.Abstract;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<List<ResultCategoryDto>> GetActiveCategoryAsync()
        {
            string query = "SELECT * FROM CATEGORY WHERE CategoryStatus= 1";
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
        public async Task<List<ResultCategoryDto>> GetPassiveCategoryAsync()
        {
            string query = "SELECT * FROM CATEGORY WHERE CategoryStatus= 0";
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
        public async Task<bool> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var query = @"INSERT INTO [dbo].[Category] ([CategoryName],[CategoryStatus]) VALUES (@CategoryName,@CategoryStatus)";
            var parameters = new DynamicParameters();
            var status = categoryDto.CategoryStatus == "true" || categoryDto.CategoryStatus == "evet" ? 1 : 0;
            parameters.Add("@CategoryName", categoryDto.CategoryName);
            parameters.Add("@CategoryStatus", status);
            using (var connection = _msSqlServerContex.CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(query, parameters);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var query = $"DELETE FROM [dbo].[Category] WHERE CategoryID=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", categoryId);
            using (var connection = _msSqlServerContex.CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(query, parameters);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var parameters = new DynamicParameters();
            if (!string.IsNullOrEmpty(categoryDto.CategoryName))
            {
                string query = "UPDATE [dbo].[Category] SET [CategoryName] = @CategoryName WHERE [CategoryID]=@CategoryID";
                parameters.Add("@CategoryName", categoryDto.CategoryName);
                parameters.Add("@CategoryID", categoryDto.CategoryID);
                using (var connection = _msSqlServerContex.CreateConnection())
                {
                    try
                    {
                        await connection.ExecuteAsync(query, parameters);
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> SetPassiveCategoryAsync(SetPassiveCategoryDto categoryDto)
        {
            var parameters = new DynamicParameters();

            string query = "UPDATE [dbo].[Category] SET [CategoryStatus] = @CategoryStatus WHERE [CategoryID]=@CategoryID";
            parameters.Add("@CategoryStatus", 0);
            parameters.Add("@CategoryID", categoryDto.CategoryID);
            using (var connection = _msSqlServerContex.CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(query, parameters);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
        public async Task<bool> SetActiveCategoryAsync(SetActiveCategoryDto categoryDto)
        {
            var parameters = new DynamicParameters();

            string query = "UPDATE [dbo].[Category] SET [CategoryStatus] = @CategoryStatus WHERE [CategoryID]=@CategoryID";
            parameters.Add("@CategoryStatus", 1);
            parameters.Add("@CategoryID", categoryDto.CategoryID);
            using (var connection = _msSqlServerContex.CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(query, parameters);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public async Task<ResultCategoryDto> GetCategoryByIDAsync(int id)
        {
            string query = "Select * from Category where CategoryID =@id";
            using (var connection = _msSqlServerContex.CreateConnection())
            {
                var parameters = new DynamicParameters();
                if (id is not 0)
                {
                    parameters.Add("@id", id);
                    try
                    {
                        var value =  connection.QueryFirstOrDefault<ResultCategoryDto>(query, parameters);
                        if (value != null)
                            return value;
                        else
                            return null;
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }

                }
                else
                {
                    return null;
                }
            }
        }
    }
}
