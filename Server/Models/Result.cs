using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UranusAdmin.Models;

namespace UranusWeb.Server.Models
{
    public class Result
    {
        [Key]
        public int? Id { get; set; }
        public string? Username { get; set; }
        public int? Points { get; set; }
        [ForeignKey("About")]
        public int? AboutId { get; set; }
        public About? About { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
