namespace eva_webApp.Model
{
    public class BodyMeasurement
    {
        public BodyMeasurement()
        {

        }

        public BodyMeasurement(int id, int userId, decimal weight, decimal height, decimal bodyFatPercentage, DateTime date)
        {
            Id = id;
            UserId = userId;
            Weight = weight;
            Height = height;
            BodyFatPercentage = bodyFatPercentage;
            Date = date;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal BodyFatPercentage { get; set; }
        public DateTime Date { get; set; }
    }
}
