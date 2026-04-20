namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dtos
{
    public class EmployeeDto
    {
        //[key]    attribuite not required here. Dto's are used to transfer the data.
        
        public int empid { get; set; }

        public string empname { get; set; }

        public int empSalary { get; set; }

    }
}
