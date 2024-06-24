using LeaveManagementAPI.Exceptions;
using LeaveManagementAPI.Interfaces;
using LeaveManagementAPI.Models;
using LeaveManagementAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementAPI.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    [EnableCors("ReactCors")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        private readonly ILogger<LeaveController> _logger;

        public LeaveController(ILeaveService leaveService,ILogger<LeaveController> logger)
        {
            _leaveService=leaveService;
            _logger = logger;
        }
        [HttpPost("Add")]
        [Authorize]
        [ProducesResponseType(typeof(Leave), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Leave>> Add(Leave item)
        {
            try
            {
                var result = await _leaveService.Add(item);
                if(result != null)
                {
                    return Ok(result);
                }
            }
            catch(DatabaseException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Can't add at this time");
        }

        [Authorize]
        [HttpDelete("Remove")]
        [ProducesResponseType(typeof(Leave), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Leave>> Remove(LeaveDTO item)
        {
            try
            {
                var result = await _leaveService.Remove(item.Id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Can't delete at this time");
        }

        [Authorize(Roles ="Manager")]
        [HttpPut("Update")]
        [ProducesResponseType(typeof(Leave), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Leave>> Update(LeaveDTO leaveDTO)
        {
            try
            {
                var result = await _leaveService.Update(leaveDTO);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Can't update at this time");
        }

        [Authorize]
        [HttpPost("GetOne")]
        [ProducesResponseType(typeof(Leave), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Leave>> Get(LeaveDTO item)
        {
            try
            {
                var result = await _leaveService.Get(item.Id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Can't get at this time");
        }

        [Authorize(Roles ="Manager")]
        [HttpPost("GetAllByManager")]
        [ProducesResponseType(typeof(List<Leave>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Leave>>> GetAllByManager(LeaveDTO item)
        {
            try
            {
                var result = await _leaveService.GetAllByManager(item.Manager_Id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Can't get at this time");
        }

        [Authorize(Roles = "Manager")]
        [HttpPost("GetAllByEmp")]
        [ProducesResponseType(typeof(List<Leave>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Leave>>> GetAllByEmp(LeaveDTO item)
        {
            try
            {
                var result = await _leaveService.GetAllByEmp(item.Emp_Id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Can't get at this time");
        }
    }
}
