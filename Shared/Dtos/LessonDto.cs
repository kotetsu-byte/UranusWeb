namespace UranusWeb.Server.Dtos
{
    public class LessonDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public CourseDto? Course { get; set; }
        public int? CourseId { get; set; }
    }
}
