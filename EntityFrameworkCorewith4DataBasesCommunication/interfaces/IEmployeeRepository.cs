using EntityFrameworkCorewith4DataBasesCommunication.Entities;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces
{
    public interface IEmployeeRepository
    {

        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int empid);

        Task<int> AddEmployees(Employee empdetail);

        Task<bool> DeleteEmployeesById(int empid);

        Task<bool> UpdateEmployee(Employee empdetail)   ;






    }
}
