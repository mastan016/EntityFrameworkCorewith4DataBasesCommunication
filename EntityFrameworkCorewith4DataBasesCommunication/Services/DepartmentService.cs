using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dtos;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> AddDepartments(DepartmentDto deptdetail)
        {
            // In future this code was replaced by automapper concept.

            Department dept = new Department();
            dept.DepartmentId= deptdetail.DepartmentId;
            dept.DepartmentName=deptdetail.DepartmentName;
            dept.DepartmentLocation= deptdetail.DepartmentLocation;
            dept.EmployeeName=deptdetail.EmployeeName;
            var res = await _departmentRepository.AddDepartment(dept);
            return res;
           
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _departmentRepository.DeleteDepartmentById(deptid);
            return true;
            
        }

        public async Task<DepartmentDto> GetDepartmentById(int deptid)
        {
            var res=await _departmentRepository.GetDepartmentById(deptid);
            DepartmentDto deptdto=new DepartmentDto();

            deptdto.DepartmentId= res.DepartmentId;
            deptdto.DepartmentName = res.DepartmentName;
            deptdto.DepartmentLocation = res.DepartmentLocation;
            deptdto.EmployeeName = res.EmployeeName;

            return deptdto;
        }

        public async Task<List<DepartmentDto>> GetDepartments()
        {

            List<DepartmentDto> lstdetpdto=new List<DepartmentDto>();
            var res = await _departmentRepository.GetDepartments();

            foreach (Department dept in res) {
                DepartmentDto deptdto=new DepartmentDto();
                deptdto.DepartmentId= dept.DepartmentId;
                deptdto.DepartmentName=dept.DepartmentName;
                deptdto.DepartmentLocation= dept.DepartmentLocation;
                deptdto.EmployeeName= dept.EmployeeName;
                lstdetpdto.Add(deptdto);    
            }
           
            return lstdetpdto;
        }

        public async Task<bool> UpdateDepartment(DepartmentDto deptdetail)
        {

            Department dept = new Department();
            dept.DepartmentId = deptdetail.DepartmentId;
            dept.DepartmentName= deptdetail.DepartmentName;
            dept.DepartmentLocation= deptdetail.DepartmentLocation; 
            dept.EmployeeName= deptdetail.EmployeeName;

            await _departmentRepository.UpdateDepartment(dept);

            return true;
            
        }
    }
}
