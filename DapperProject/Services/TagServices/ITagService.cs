using DapperProject.Dtos.TagDtos;


namespace DapperProject.Services.TagServices
{
    public interface ITagService
    {
        Task<List<ResultTagDto>> GetAllTagAsync();
        Task CreateTagAsync(CreateTagDto createTagDto);
        Task DeleteTagAsync(int id);
        Task UpdateTagAsync(UpdateTagDto updateTagDto);
        Task<GetByIdTagDto> GetTagAsync(int id);
    }
}
