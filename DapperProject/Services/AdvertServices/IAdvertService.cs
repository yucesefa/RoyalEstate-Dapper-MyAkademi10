using DapperProject.Dtos.AdvertDtos;

namespace DapperProject.Services.AdvertServices
{
    public interface IAdvertService
    {
        Task<List<Last6AdvertDto>> GetLast6AdvertAsync();
        Task<List<Last4AdvertDto>> GetLast4AdvertAsync();
    }
}
