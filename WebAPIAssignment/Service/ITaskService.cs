
using Microsoft.AspNetCore.Mvc;
using WebAPIAssignment.Model;

namespace WebAPIAssignment.Service
{
    public interface ITaskService
    {
        void AddProjectTask(ProjectTask todoItem);
        void DeleteProjectTaskById(int id);
        Task<ProjectTask> FindProjectTaskById(int id);
        Task<ActionResult<IEnumerable<ProjectTask>>> GetAll();
        void UpdateProjectTask(ProjectTask todoItem);
    }
}
