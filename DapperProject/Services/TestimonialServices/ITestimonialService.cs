using DapperProject.Dtos.TestimonialDtos;
using DapperProject.Dtos.TestimonialDtos;

namespace DapperProject.Services.TestimonialServices
{
	public interface ITestimonialService
	{
		Task<int> GetAllTestimonialCountAsync();
		Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();

        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task DeleteTestimonialAsync(int id);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task<GetByIdTestimonialDto> GetTestimonialAsync(int id);
    }
}
