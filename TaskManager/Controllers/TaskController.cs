using Microsoft.AspNetCore.Mvc;
using TaskManager.DAL.Utils;
using TaskManager.BLL.Interfaces;
using TaskManager.DAL.Exceptions;
using Microsoft.AspNet.OData;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetTask")]
        [EnableQuery]
        public async Task<IActionResult> GetTask([FromODataUri] int taskId)
        {
            try
            {
                var task = await _taskService.GetTask(taskId);
                return Ok(task);
            }
            catch(CustomException cex)
            {
                return BadRequest($"Error Type: {cex.ExceptionType.ToErrorMessage()} Message: {cex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditTask")]
        [EnableQuery]
        public async Task<IActionResult> EditTask([FromODataUri] DAL.Context.Task task)
        {
            try
            {
                await _taskService.UpdateTask(task);
                return Ok("Success");
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

        [HttpPost("AddTask")]
        [EnableQuery]
        public async Task<IActionResult> AddTask([FromODataUri] DAL.Context.Task task)
        {
            try
            {
                await _taskService.AddTask(task);
                return Ok("Success");
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

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var task = await _taskService.GetAllTasks();
                return Ok(task);
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

        [HttpGet("GetTaskSummary")]
        public async Task<IActionResult> GetTaskSummary(int taskId)
        {
            try
            {
                var summary = await _taskService.GetTaskSummaryFromAPI(taskId);
                return Ok(summary);
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
