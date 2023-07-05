using AkademiPlusMikroServiceProje.Shared.Dtos;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Frontend.Services.Abstract
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn();
    }
}
