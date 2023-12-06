using Microsoft.EntityFrameworkCore;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;
using UranusWeb.Server.Models;

namespace UranusWeb.Server.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppDbContext _context;

        public ResultRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Result>> GetAllResults(int courseId, int aboutId)
        {
            return await _context.Results.Where(r => r.CourseId == courseId && r.AboutId == aboutId).ToListAsync();
        }

        public async Task<Result> GetResultById(int courseId, int aboutId, int id)
        {
            return await _context.Results.Where(r => r.CourseId == courseId && r.AboutId == aboutId && r.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Result result)
        {
            _context.Results.Add(result);

            return Save();
        }

        public bool Update(Result result)
        {
            _context.Results.Update(result);

            return Save();
        }

        public bool Delete(int id)
        {
            var result = _context.Results.Where(r => r.Id == id).FirstOrDefault();

            _context.Results.Remove(result);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
