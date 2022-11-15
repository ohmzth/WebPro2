using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Issue
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Priorty Priorty { get; set; }
        public IssueType IssueType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }

    }
    public enum Priorty
    {
        Low,Medium,High
    }
    public enum IssueType
    {
        Feature,Ducumentation,Bug
    }
}
