namespace DapperProject.Dtos.AdvertDtos
{
    public class UpdateAdvertDto
    {
        public int AdvertId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int M2 { get; set; }
        public int BathroomCount { get; set; }
        public int RoomCount { get; set; }
        public int Price { get; set; }
        public bool AdvertStatus { get; set; }
        public string VideoEmbed { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl1 { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}
