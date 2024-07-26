using DapperProject.Dtos.AdvertDtos;
using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.AdvertServices
{
    public interface IAdvertService
    {
        Task<List<Last6AdvertDto>> GetLast6AdvertAsync();
        Task<List<Last4AdvertDto>> GetLast4AdvertAsync();
        Task<List<Last2AdvertDto>> GetLast2AdvertAsync();
        Task<int> GetAdvertCount();
        Task<List<GetAdvertDetailCategoryCount>> GetAdvertDetailCategoryCountsAsync();
        Task<GetByIdAdvertDetailDto> GetByIdAdvertAsync(int id);
        Task<List<ResultAdvertDto>> GetResultAdvertAsync();
        Task<List<ResultSliderDto>> GetResultSliderAdvertAsync();
        Task<List<GetListSearchAdvertDto>> GetListSearchAdvertAsync(int location,int category);
        Task CreateAdvertAsync(CreateAdvertDto createAdvertDto);
        Task DeleteAdvertAsync(int id);
        Task UpdateAdvertAsync(UpdateAdvertDto updateAdvertDto);
        Task<GetByIdAdvertDto> GetAdvertAsync(int id);
    }
}
