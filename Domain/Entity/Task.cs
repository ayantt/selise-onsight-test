namespace Domain.Entity
{
    public class Task
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid AssignedToUserId { get; set; }
        public Guid TeamId { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
