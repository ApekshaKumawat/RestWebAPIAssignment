using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAssignment.Model;
using WebAPIAssignment.Service;

namespace WebAPIAssignment.Controllers
{
    public class ProjectTasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public ProjectTasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("api/ProjectTasks/All")]
        public async Task<ActionResult<IEnumerable<ProjectTask>>> GetAllProjectTasks()
        {
            if(_taskService.GetAll == null)
            {
                return NotFound();
            }
            return await _taskService.GetAll();
        }

        [HttpGet]
        [Route("api/ProjectTasks/{id}")]
        public async Task<ProjectTask> GetTaskById(int id)
        {
            return await _taskService.FindProjectTaskById(id); 
        }

        [HttpPost]
        [Route("api/ProjectTasks")]
        public async Task<ActionResult<ProjectTask>> PostTodoItem(ProjectTask todoItem)
        {
            _taskService.AddProjectTask(todoItem);
            return CreatedAtAction(nameof(PostTodoItem), new { id = todoItem.TaskId }, todoItem);
        }

        [HttpPut]
        [Route("api/ProjectTasks")]
        public async Task<ActionResult<ProjectTask>> UpdateProjectTask(ProjectTask todoItem)
        {
            _taskService.UpdateProjectTask(todoItem);
            return CreatedAtAction(nameof(PostTodoItem), new { id = todoItem.TaskId }, todoItem);
        }

        [HttpDelete]
        [Route("api/DeleteTask")]
        public ActionResult Delete(int id)
        {
            var task = _taskService.FindProjectTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            _taskService.DeleteProjectTaskById(id);
            return Ok(); 
        }

    }
}
