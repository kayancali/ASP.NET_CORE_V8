using BlogApp.Data.Abstract;
using BlogApp.Data.Conrete.EfCore;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore; // DbSet için gerekli

namespace BlogApp.Data.Concrete
{
    public class EfCommentRepository : ICommentRepository
    {
        private readonly BlogContext _context;

        public EfCommentRepository(BlogContext context)
        {
            _context = context;
        }

  
        public IQueryable<Comment> Comments => _context.Comments;

        public void CreateComment(Comment Comment)
        {
            _context.Comments.Add(Comment);
            _context.SaveChanges();
        }
    }
}
