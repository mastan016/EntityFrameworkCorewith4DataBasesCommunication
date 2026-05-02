using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dbconnect;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DepartmentContext _departmentcontext;
         
        public DepartmentRepository(DepartmentContext departmentcontext)
        {
            _departmentcontext = departmentcontext;
        }

        public async Task<int> AddDepartment(Department departmentdetail)
        {
            await _departmentcontext.Departments.AddAsync(departmentdetail);
            _departmentcontext.SaveChanges();  //it will commit/save the data perminently 

            return 1;                                    
        }

        public async Task<bool> DeleteDepartmentById(int departmentid)
        {

            var result = await _departmentcontext.Departments.Where(a => a.DepartmentId == departmentid).FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            else
            {

                _departmentcontext.Departments.Remove(result);
                _departmentcontext.SaveChanges();
                return true;
            }
        }

        public async Task<Department> GetDepartmentById(int departmentid)
        {
            var result = await _departmentcontext.Departments.Where(o => o.DepartmentId == departmentid).FirstOrDefaultAsync();
            if(result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
            
        }

        public async Task<List<Department>> GetDepartments()
        {
            var result =  await _departmentcontext.Departments.ToListAsync();

            if(result.Count==0)
            {
                return null;
            }
            else
            {
                return result;
            }
           
        }

        public async Task<bool> UpdateDepartment(Department departmentdetail)
        {
            _departmentcontext.Departments.Update(departmentdetail);
            await _departmentcontext.SaveChangesAsync();
            return true;                
        }
    }
}
