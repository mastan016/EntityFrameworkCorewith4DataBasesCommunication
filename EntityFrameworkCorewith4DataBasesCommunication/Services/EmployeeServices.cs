using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dtos;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces;
using EntityFrameworkCorewith4DataBasesCommunication.Entities;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            //Inject the dependencies in constructor.
            _employeeRepository = employeeRepository;
        }
        public async Task<int> AddEmployees(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.empid = empdetail.empid;
            emp.empSalary = empdetail.empSalary;
            emp.empname = empdetail.empname;
            var res=await _employeeRepository.AddEmployees(emp);
            return res;           
        }

        public async Task<bool> DeleteEmployeesById(int empid)
        {
            await _employeeRepository.DeleteEmployeesById(empid);
            return true;
                        
        }

        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {

            var res = await _employeeRepository.GetEmployeeById(empid);
            EmployeeDto empdto=new EmployeeDto();
            empdto.empid = res.empid;
            empdto.empname = res.empname;
            empdto.empSalary = res.empSalary;

            return empdto;

        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {

            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            var res = await _employeeRepository.GetEmployees();
            
            foreach (Employee emp in res)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.empid=emp.empid;
                empdto.empSalary=emp.empSalary;
                empdto.empname=emp.empname;
                lstempdto.Add(empdto);
            }
            return lstempdto;
        }

        public async Task<bool> UpdateEmployee(EmployeeDto empdetail)
        {
            Employee emp=new Employee();
            emp.empid = empdetail.empid;
            emp.empSalary= empdetail.empSalary;
            emp.empname = empdetail.empname;
            await _employeeRepository.UpdateEmployee(emp);
            return true;
           
        }
    }
}
