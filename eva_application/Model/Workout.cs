namespace eva_webApp.Model
{
    public class Workout
    {
        public Workout()
        {

        }
        public Workout(int id, int userId, string name, string description, int duration, DateTime date)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Description = description;
            Duration = duration;
            Date = date;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public int Duration { get; set; }
        public DateTime Date { get; set; }
    }
}
