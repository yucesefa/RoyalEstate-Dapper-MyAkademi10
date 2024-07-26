namespace DapperProject.Dtos.AdvertDtos
{
    public class SearchAdvertDto
    {
        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public int? MinM2 { get; set; }
        public int? MaxM2 { get;}
        public int? MinRoomCount { get; set; }
        public int? MinBathroomCount { get; set; }
    }
}
