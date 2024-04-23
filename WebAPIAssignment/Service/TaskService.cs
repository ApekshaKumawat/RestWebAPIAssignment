
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAssignment.Model;

namespace WebAPIAssignment.Service
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        public TaskService(ApplicationDbContext context) { 
            _context = context;
        }

        public async void AddProjectTask(ProjectTask todoItem)
        {
            _context.ProjectTasks.Add(todoItem);
            await _context.SaveChangesAsync();
        }

        public async void DeleteProjectTaskById(int id)
        {
            _context.ProjectTasks.Remove(await this.FindProjectTaskById(id));
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectTask> FindProjectTaskById(int id)
        {
            return await _context.ProjectTasks.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<ProjectTask>>> GetAll()
        {
            return await _context.ProjectTasks.ToListAsync();                           
        }

        public async void UpdateProjectTask(ProjectTask todoItem)
        {
            _context.ProjectTasks.Update(todoItem);
            await _context.SaveChangesAsync();
        }
    }
}
