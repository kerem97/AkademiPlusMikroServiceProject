using AkademiPlusMikroServiceProje.Shared.Dtos;
using AkademiPlusMikroServiceProject.Basket.DTOs;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string UserID);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> DeleteBasket(string UserID);
    }
}
