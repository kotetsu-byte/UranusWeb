namespace UranusWeb.Shared.Dtos
{
    public class ReviewDto
    {
        public int? Id { get; set; }
        public string? Author { get; set; }
        public string? Text { get; set; }
        public int? AboutId { get; set; }
        public int? CourseId { get; set; }
    }
}
