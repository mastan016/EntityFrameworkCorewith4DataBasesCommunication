using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dtos;
using EntityFrameworkCorewith4DataBasesCommunication.Entities;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces
{
    public interface IEmployeeService
    {

        Task<List<EmployeeDto>> GetEmployees();

        Task<EmployeeDto> GetEmployeeById(int empid);

        Task<int> AddEmployees(EmployeeDto empdetail);

        Task<bool> DeleteEmployeesById(int empid);

        Task<bool> UpdateEmployee(EmployeeDto empdetail);

    }
}
