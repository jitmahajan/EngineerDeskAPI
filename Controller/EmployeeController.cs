using DataBaseProject.Interface;
using DataBaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace EngineerDeskAPI.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IEmployeeRepository _EmployeeRepository;


        public EmployeeController (IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            try
            {
                var employees = _EmployeeRepository.GetAllEmployees();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }


        [HttpGet]
        public ActionResult GetEmployee(int Id)
        {
            try
            {
                var employee = _EmployeeRepository.GetEmployeeByID(Id);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                var addEmployee = _EmployeeRepository.AddEmployee(employee);
                return Ok(addEmployee);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);

            }
        }
    }
}
