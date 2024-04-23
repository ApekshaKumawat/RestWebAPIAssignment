using System.ComponentModel.DataAnnotations;

namespace WebAPIAssignment.Model
{
    public class ProjectTask
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
    }
}
