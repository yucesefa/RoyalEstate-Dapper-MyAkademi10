using DapperProject.Dtos.TestimonialDtos;

namespace DapperProject.Services.TestimonialServices
{
	public interface ITestimonialService
	{
		Task<int> GetAllTestimonialCountAsync();
		Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync();
	}
}
