namespace SearchEngine.API.Models
{
    public class Place
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string OpenHours { get; set; }
        public string PhotoURL { get; set; }
        public decimal Rating { get; set; }
    }
}