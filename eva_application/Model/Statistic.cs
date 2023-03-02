namespace eva_webApp.Model
{
    public class Statistic
    {
        public Statistic()
        {

        }
        public Statistic(int id, int userId, int workoutId, int sets, int reps, int weight)
        {
            Id = id;
            UserId = userId;
            WorkoutId = workoutId;
            Sets = sets;
            Reps = reps;
            Weight = weight;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkoutId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}
