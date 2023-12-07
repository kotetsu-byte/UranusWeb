using Microsoft.EntityFrameworkCore;
using UranusAdmin.Models;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;

namespace UranusWeb.Server.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Material>> GetAllMaterials(int courseId, int lessonId, int homeworkId)
        {
            return await _context.Materials.Where(m => m.CourseId == courseId && m.LessonId == lessonId && m.HomeworkId == homeworkId).ToListAsync();
        }

        public async Task<Material> GetMaterialById(int courseId, int lessonId, int homeworkId, int id)
        {
            return await _context.Materials.Where(m => m.CourseId == courseId && m.LessonId == lessonId && m.HomeworkId == homeworkId && m.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Material material)
        {
            _context.Materials.Add(material);

            return Save();
        }

        public bool Update(Material material)
        {
            _context.Materials.Update(material);

            return Save();
        }

        public bool Delete(int id)
        {
            var material = _context.Materials.Where(m => m.Id == id).FirstOrDefault();
            
            _context.Materials.Remove(material);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
