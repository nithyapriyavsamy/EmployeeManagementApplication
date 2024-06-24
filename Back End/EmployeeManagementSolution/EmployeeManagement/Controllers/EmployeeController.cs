using EmployeeManagement.ErrorMessages;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("ReactCors")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUpdateService _updateService;
        Error? error;
        private ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService,
                                   IUpdateService updateService,ILogger<EmployeeController> logger)
        {
            _employeeService= employeeService;
            _updateService= updateService;
            error = new Error();
            _logger = logger;
        }

        
        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<UserDTO?>> Register(EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = await _employeeService.Register(employeeDTO);
                if (employee != null)
                    return Created("Employee Added", employee);
                error.ID = 400;
                error.Message = new Messages().messages[3];
                return BadRequest(error);
            }
            catch (Exception)
            {
                error.ID = 400;
                error.Message = new Messages().messages[4];
                _logger.LogError(error.Message);
            }

            return BadRequest(error);
        }
        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<UserDTO?>> Login(UserDTO userDTO)
        {
            try
            {
                var user = await _employeeService.Login(userDTO);
                if (user != null)
                    return Ok(user);
                error.ID = 400;
                error.Message = new Messages().messages[2];
                return BadRequest(400);
            }
            catch (Exception)
            {
                error.ID = 400;
                error.Message = new Messages().messages[4];
                _logger.LogError(error.Message);
            }

            return BadRequest(error);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee?>> GetEmployee(UserIdDTO id)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(id);
                if (employee != null)
                    return Ok(employee);
                error.ID = 404;
                error.Message = new Messages().messages[1];
                return NotFound(error);
            }
            catch (Exception)
            {
                error.ID = 400;
                error.Message = new Messages().messages[4];
                _logger.LogError(error.Message);
            }

            return BadRequest(error);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ProducesResponseType(typeof(List<ListEmployeeDTO>), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<ListEmployeeDTO>>> GetEmployees(UserIdDTO id)
        {
            try { 
            var employee = await _employeeService.GetEmployees(id.UserId);
            if (employee != null)
                return Ok(employee);
            error.ID = 404;
            error.Message = new Messages().messages[1];
            return NotFound(error);
            }
            catch (Exception)
            {
                error.ID = 400;
                error.Message = new Messages().messages[4];
                _logger.LogError(error.Message);
            }
            return BadRequest(error);
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee?>> UpdateAll(UpdateDTO update)
        {
            var employee = await _updateService.Update(update);
            if (employee != null)
                return Ok(employee);
            return BadRequest(error);
        }

        [HttpPut]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User?>> UpdateEmployeeStatus(StatusDTO statusDTO)
        {
            try
            {
                var employee = await _updateService.UpdateStatus(statusDTO);
                if (employee != null)
                    return Ok(employee);
                error.ID = 404;
                error.Message = new Messages().messages[5];
                return NotFound(error);
            }
            catch (Exception)
            {
                error.ID = 400;
                error.Message = new Messages().messages[4];
                _logger.LogError(error.Message);
            }
            return BadRequest(error);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        public async Task<ActionResult<User?>> GetUser(UserIdDTO id)
        {
            var user=await _employeeService.GetUser(id);
            if(user != null)
                return Ok(user);
            error.ID = 404;
            error.Message= new Messages().messages[1];
            return NotFound(error);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        public async Task<ActionResult<List<ListEmployeeDTO>?>> GetAllEmployees()
        {
            var employees= await _employeeService.GetAllEmployees();
            if (employees != null)
                return Ok(employees);
            error.ID = 404;
            error.Message=new Messages().messages[1];
            return NotFound(error);
        }
    }
}
