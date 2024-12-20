using Microsoft.AspNetCore.Routing.Template;
using razorpagesExample.Models;

namespace razorpagesExample.Repository;

public class MySQLEmployeeRepository : IEmployeeRepository
{   
    private readonly DataContext _context;

    public MySQLEmployeeRepository(DataContext context)
    {
        _context = context;
    }
    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees.ToList();
    }

    public Employee GetById(int id)
    {
        return _context.Employees.FirstOrDefault(x => x.Id == id);
    }

    public Employee Update(Employee entity)
    {
        var entityToUpdate = _context.Employees.FirstOrDefault(x => x.Id == entity.Id);

        if (entityToUpdate != null)
        {
        entityToUpdate.Photo = entity.Photo;
        entityToUpdate.Name = entity.Name;
        entityToUpdate.Deparment=entity.Deparment;
        entityToUpdate.Email = entity.Email;
        _context.SaveChanges();
        }

        return entityToUpdate;
       
        
    }
}
