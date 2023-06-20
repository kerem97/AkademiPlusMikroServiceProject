using AkademiPlusMikroServiceProje.Shared.Dtos;
using AkademiPlusMikroServiceProject.Basket.DTOs;
using System.Text.Json;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> DeleteBasket(string UserID)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(UserID);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail(404, "Sepet bulunamadı");
        }

        public async Task<Response<BasketDto>> GetBasket(string UserID)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(UserID);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail(404, "Sepet Bulunamadı");
            }
            else
            {
                return Response<BasketDto>.Success(200, JsonSerializer.Deserialize<BasketDto>(existBasket));
            }
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserID, JsonSerializer.Serialize(basketDto));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail(404, "Bir hata oluştu");
        }
    }
}
