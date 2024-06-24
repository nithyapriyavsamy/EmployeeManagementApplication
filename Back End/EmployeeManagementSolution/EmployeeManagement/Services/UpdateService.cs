using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs;

namespace EmployeeManagement.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IEmployeeRepo<Employee, int> _employeeRepo;
        private readonly IEmployeeRepo<User, int> _userRepo;

        public UpdateService(IEmployeeRepo<Employee, int> employeeRepo, IEmployeeRepo<User, int> userRepo)
        {
            _employeeRepo = employeeRepo;
            _userRepo = userRepo;
        }

        public async Task<Employee?> Update(UpdateDTO update)
        {
            Employee? employee = new Employee();
            employee = await _employeeRepo.Get(update.EmployeeId);
            if (employee == null) return null;
            if (update.UpdatedPhoneNo != "")
            {
                employee.Phone = update.UpdatedPhoneNo;
            }
            if (update.UpdatedPassportNo != "")
            {
                employee.PassportNumber = update.UpdatedPassportNo;
            }
            if (update.UpdatedLicenceNo != "")
            {
                employee.LicenseNumber = update.UpdatedLicenceNo;
            }
            if (update.UpdatedAddress != "")
            {
                employee.Address = update.UpdatedAddress;
            }
            employee = await _employeeRepo.Update(employee);
            if (employee != null)
            {
                return employee;
            }
            return null;
        }

        public async Task<User?> UpdateStatus(StatusDTO statusDTO)
        {          
            var user = await _userRepo.Get(statusDTO.EmployeeID);
            if(user==null) { return null; }
            user.ManagerId = statusDTO.ManagerID;
            var checkUser = await _userRepo.Update(user);
            if(checkUser != null)
              return checkUser;
            else
               return null;
        }
    }
}
