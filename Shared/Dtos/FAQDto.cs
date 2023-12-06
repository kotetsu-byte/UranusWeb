namespace UranusWeb.Shared.Dtos
{
    public class FAQDto
    {
        public int? Id { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int? AboutId { get; set; }
        public int? CourseId { get; set; }
    }
}
