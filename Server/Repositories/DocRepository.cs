using Microsoft.EntityFrameworkCore;
using UranusAdmin.Models;
using UranusWeb.Server.Data;
using UranusWeb.Server.Interfaces;

namespace UranusWeb.Server.Repositories
{
    public class DocRepository : IDocRepository
    {
        private readonly AppDbContext _context;

        public DocRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doc>> GetAllDocs()
        {
            return await _context.Docs.ToListAsync();
        }

        public async Task<Doc> GetDocById(int id)
        {
            return await _context.Docs.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Doc doc)
        {
            _context.Docs.Add(doc);

            return Save();
        }

        public bool Update(Doc doc)
        {
            _context.Docs.Update(doc);

            return Save();
        }

        public bool Delete(int id)
        {
            var doc = _context.Docs.Where(d => d.Id == id).FirstOrDefault();
            
            _context.Docs.Remove(doc);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
