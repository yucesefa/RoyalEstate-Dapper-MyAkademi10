using DapperProject.Dtos.TagDtos;

namespace DapperProject.Services.TagServices
{
    public interface ITagService
    {
        Task<List<ResultTagDto>> GetAllTagAsync();
    }
}
