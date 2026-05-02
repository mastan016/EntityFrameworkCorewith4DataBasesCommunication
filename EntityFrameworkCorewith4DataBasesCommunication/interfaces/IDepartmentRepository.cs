using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces
{
    public interface IDepartmentRepository
    {

        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int orderid);

        Task<int> AddDepartment(Department departmentdetail);

        Task<bool> DeleteDepartmentById(int departmentid);

        Task<bool> UpdateDepartment(Department departmentdetail);


    }
}
