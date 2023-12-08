using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UranusWeb.Server.Models;
using static System.Net.Mime.MediaTypeNames;

namespace UranusAdmin.Models
{
    public class Course
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
        public double? Price { get; set; }
        public ICollection<Test>? Tests { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
        public About? About { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
