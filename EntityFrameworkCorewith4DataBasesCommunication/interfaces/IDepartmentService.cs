using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dtos;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetDepartments();
        Task<DepartmentDto> GetDepartmentById(int deptid);

        Task<int> AddDepartments(DepartmentDto deptdetail);

        Task<bool> DeleteDepartmentById(int deptid);

        Task<bool> UpdateDepartment(DepartmentDto deptdetail);
    }
}
