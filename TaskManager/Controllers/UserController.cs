using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using TaskManager.BLL.Interfaces;
using TaskManager.DAL.Utils;
using TaskManager.DAL.Exceptions;
using TaskManager.BLL.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser")]
        [EnableQuery]
        public async Task<IActionResult> Get([FromODataUri] int userId)
        {
            try
            {
                var user = await _userService.GetUser(userId);
                return Ok(user);
            }
            catch (CustomException cex)
            {
                return BadRequest($"Error. Type: {cex.ExceptionType.ToErrorMessage()} Message: {cex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (CustomException cex)
            {
                return BadRequest($"Error Type: {cex.ExceptionType.ToErrorMessage()} Message: {cex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
