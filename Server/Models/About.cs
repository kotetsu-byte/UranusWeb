using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UranusAdmin.Models;

namespace UranusWeb.Server.Models
{
    public class About
    {
        [Key]
        public int? Id { get; set; }
        public string? Content { get;set; }
        public IEnumerable<Review>? Reviews { get; set; }
        public IEnumerable<Result>? Results { get; set; }
        public PartVideo? LessonPartVideo { get; set; }
        public IEnumerable<FAQ>? FAQs { get; set; }
        public double? Price { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
