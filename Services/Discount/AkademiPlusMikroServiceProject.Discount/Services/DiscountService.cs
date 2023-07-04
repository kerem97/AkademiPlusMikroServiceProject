using AkademiPlusMikroServiceProje.Shared.Dtos;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public Task<Response<NoContent>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discount = await _dbConnection.QueryAsync<Models.Discount>("Select*From discount");
            return Response<List<Models.Discount>>.Success(200, discount.ToList());
        }

        public Task<Response<Models.Discount>> GetByCodeWithUserId(string code, string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<Models.Discount>> GetByID(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("Select*From discount where id=@Id", new { Id = id })).SingleOrDefault();
            return Response<Models.Discount>.Success(200, discount);

        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("insert into discount (userId,rate,code)values(@userId,@rate,@code)", discount);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userId=@userid,code=@code,rate=@rate where id=@Id", new { Id = discount.Id, userId = discount.UserID, rate = discount.Rate, code = discount.Code });
            return Response<NoContent>.Success(204);
        }
    }
}
