using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UranusAdmin.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Username { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
