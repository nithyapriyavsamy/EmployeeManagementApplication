using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmployeeManagement.Services
{
    public class EmployeeRepo:IEmployeeRepo<Employee,int>
    {
        private readonly EmployeeContext _context;

        public EmployeeRepo(EmployeeContext context)
        {
            _context=context;
        }

        public async Task<Employee?> Add(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Employee?> Delete(int id)
        {
            try
            {
                var employee = await Get(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Employee?> Get(int id)
        {
            try
            {
                var user = await _context.Employees.SingleOrDefaultAsync(u=>u.EmployeeId==id);
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

        public async Task<ICollection<Employee>?> GetAll()
        {
            try
            {
                var employees = await _context.Employees.ToListAsync();
                if(employees!=null)
                    return employees;
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

public async Task<Employee?> Update(Employee employee)
        {
            var employees = Get(employee.EmployeeId);
            if (employees!=null)
            {
                try
                {
                    _context.Employees.Update(employee);
                    await _context.SaveChangesAsync();
                    return employee;
                }
                catch (Exception err)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine(err.Message);
                    Debug.WriteLine(err.Message);
                }
            }
            return null;
        }
    }
}
