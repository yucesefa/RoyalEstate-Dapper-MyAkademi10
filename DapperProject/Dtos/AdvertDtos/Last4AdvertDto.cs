namespace DapperProject.Dtos.AdvertDtos
{
    public class Last4AdvertDto
    {
        public int AdvertId { get; set; }
        public string ImageUrl { get; set; }
        public string LocationName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int M2 { get; set; }
        public int BathroomCount { get; set; }
        public int RoomCount { get; set; }
        public string AdvertType { get; set; }
        public int Price { get; set; }
        public bool AdvertStatus { get; set; }
    }
}
