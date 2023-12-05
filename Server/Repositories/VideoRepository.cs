using Microsoft.EntityFrameworkCore;
using UranusAdmin.Models;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;

namespace UranusWeb.Server.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Video>> GetAllVideos(int courseId, int lessonId)
        {
            return await _context.Videos.Where(v => v.CourseId == courseId && v.LessonId == lessonId).ToListAsync();
        }

        public async Task<Video> GetVideoById(int courseId, int lessonId, int id)
        {
            return await _context.Videos.Where(v => v.CourseId == courseId && v.LessonId == lessonId && v.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Video video)
        {
            _context.Videos.Add(video);

            return Save();
        }

        public bool Update(Video video)
        {
            _context.Videos.Update(video);

            return Save();
        }

        public bool Delete(int id)
        {
            var video = _context.Videos.Where(v => v.Id == id).FirstOrDefault();
            
            _context.Videos.Remove(video);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
