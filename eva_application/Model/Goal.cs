namespace eva_webApp.Model
{
    public class Goal
    {
        public Goal()
        {

        }
        public Goal(int id, int userId, string name, string description, DateTime endDate)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Description = description;
            TargetDate = endDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public DateTime TargetDate { get; set; }

        
    }

    public enum Status
    {
        inProgress,
        completed
    }
}
