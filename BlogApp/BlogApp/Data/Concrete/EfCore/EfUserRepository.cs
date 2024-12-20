using BlogApp.Data.Abstract;
using BlogApp.Data.Conrete.EfCore;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore; // DbSet için gerekli

namespace BlogApp.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private readonly BlogContext _context;

        public EfUserRepository(BlogContext context)
        {
            _context = context;
        }

        // Tags özelliğini uygun şekilde uygulayın
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
        }
    }
}
