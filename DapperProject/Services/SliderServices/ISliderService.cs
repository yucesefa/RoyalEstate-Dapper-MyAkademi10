using DapperProject.Dtos.SliderDtos;

namespace DapperProject.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();
    }
}
