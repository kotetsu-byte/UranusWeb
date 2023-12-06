using Microsoft.EntityFrameworkCore;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;
using UranusWeb.Server.Models;

namespace UranusWeb.Server.Repositories
{
    public class PartVideoRepository : IPartVideoRepository
    {
        private readonly AppDbContext _context;

        public PartVideoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PartVideo>> GetAllPartVideos(int courseId, int aboutId)
        {
            return await _context.PartVideos.Where(pv => pv.CourseId == courseId && pv.AboutId == aboutId).ToListAsync();
        }

        public async Task<PartVideo> GetPartVideoById(int courseId, int aboutId, int id)
        {
            return await _context.PartVideos.Where(pv => pv.CourseId == courseId && pv.AboutId == aboutId && pv.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(PartVideo partVideo)
        {
            _context.PartVideos.Add(partVideo);

            return Save();
        }

        public bool Update(PartVideo partVideo)
        {
            _context.PartVideos.Update(partVideo);

            return Save();
        }

        public bool Delete(int id) 
        {
            var partVideo = _context.PartVideos.Where(pv => pv.Id == id).FirstOrDefault();

            _context.PartVideos.Remove(partVideo);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
