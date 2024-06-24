using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services
{
    public class UserRepo : IEmployeeRepo<User, int>
    {
        private readonly EmployeeContext _context;

        public UserRepo(EmployeeContext context)
        {
            _context=context;
        }

        public async Task<User?> Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<User?> Delete(int id)
        {
            try
            {
                var user = await Get(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<User?> Get(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<User>?> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users != null)
                    return users;
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<User?> Update(User item)
        {
            var user = await Get(item.UserId); 
            if(user==null) return null;
            if(user.EmployeeState=="Quit")
            {
                user.EmployeeState = "Quit";
            }
            else if(user.EmployeeState=="Inactive")
            {
                user.EmployeeState = "Active";
                user.ManagerId= item.ManagerId;
            }
            else if (user.EmployeeState == "Active")
            {
                user.EmployeeState = "Inactive";
            }
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
