using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UranusAdmin.Models;

namespace UranusWeb.Server.Models
{
    public class Review
    {
        [Key]
        public int? Id { get; set; }
        public string? Author { get; set; }
        public string? Text { get; set; }
        [ForeignKey("About")]
        public int? AboutId { get; set; }
        public About? About { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
