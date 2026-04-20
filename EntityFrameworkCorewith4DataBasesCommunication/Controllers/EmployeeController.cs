using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dtos;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces;
using EntityFrameworkCorewith4DataBasesCommunication.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.AddEmployees(empdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {
                //if you got any error we are using this statuscode: Status 500 Internal ServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {

                var empdata=await _employeeService.GetEmployees();
                if (empdata != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);                   
                }

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }

        [HttpDelete]
        [Route("DeleteEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> delete(int empid)
        {
            if(empid<0)
            {
                //If input parameters are wrongly sent aor empty, we will get 400 bad request statuscode: Status400badRequest
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var empdata = await _employeeService.DeleteEmployeesById(empid);

                if (empdata == null)
                {
                    //in db if you get empty data we need to return this statuscode: Status404NotFound

                    return StatusCode(StatusCodes.Status400BadRequest, "empdata not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }

        }

        [HttpGet]
        [Route("GetEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> Get(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }

            try
            {
                var empdata = await _employeeService.GetEmployeeById(empid);
                return StatusCode(StatusCodes.Status200OK, empdata);            

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }

        }


        //[HttpPut]
        //[Route("UpdateEmployee")]
        //public async Task<IActionResult> put([FromBody] EmployeeDto empdto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {

        //            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var empdata = await _employeeService.UpdateEmployee(empdto);
        //            return StatusCode(StatusCodes.Status200OK, empdata);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
        //    }
        //}


    }
}
