using BlogApp.Data.Abstract;
using BlogApp.Data.Conrete.EfCore;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore; // DbSet için gerekli

namespace BlogApp.Data.Concrete
{
    public class EfTagRepository : ITagRepository
    {
        private readonly BlogContext _context;

        public EfTagRepository(BlogContext context)
        {
            _context = context;
        }

        // Tags özelliğini uygun şekilde uygulayın
        public IQueryable<Tag> Tags => _context.Tags;

        public void CreateTag(Tag Tag)
        {
            _context.Tags.Add(Tag);
            _context.SaveChanges();
        }
    }
}
