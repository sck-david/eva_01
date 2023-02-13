using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using eva_webApp.Model;
using System.Xml.Linq;
using Bogus;

namespace eva_webApp.Database
{
    
    
        public class FitnessAppContext : DbContext
        {
            public FitnessAppContext(DbContextOptions<FitnessAppContext> options)
                : base(options)
            {
            }

        public FitnessAppContext() : this(
            new DbContextOptionsBuilder<FitnessAppContext>()
            .UseSqlite("DataSource=fitness.db")
            .Options)
        {
        }

        public DbSet<User> Users { get; set; }
            public DbSet<Workout> Workouts { get; set; }
            public DbSet<Statistic> Statistics { get; set; }
            public DbSet<Goal> Goals { get; set; }
            public DbSet<BodyMeasurement> BodyMeasurements { get; set; }



        public async Task<int> SeedBogusAsync(FitnessAppContext context)
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Username, f => f.Person.UserName)
                .RuleFor(u => u.Password, f => f.Lorem.Word())
                .RuleFor(u => u.Email, f => f.Internet.Email());

            var workoutFaker = new Faker<Workout>()
                .RuleFor(w => w.Name, f => f.Commerce.ProductName())
                .RuleFor(w => w.Duration, f => f.Random.Int(1, 60))
                .RuleFor(w => w.Date, f => f.Date.Between(DateTime.Now.AddDays(-30), DateTime.Now))
                .RuleFor(w => w.UserId, f => f.Random.Int(1, context.Users.Count()))
                .RuleFor(w => w.Description, f => f.Lorem.Sentence());

            var statisticFaker = new Faker<Statistic>()
                .RuleFor(s => s.Reps, f => f.Random.Int(5, 20))
                .RuleFor(s => s.Sets, f => f.Random.Int(2, 6))
                .RuleFor(s => s.Weight, f => f.Random.Int(20, 150))
                .RuleFor(s => s.WorkoutId, f => f.Random.Int(1, context.Workouts.Count()))
                .RuleFor(s => s.UserId, f => f.Random.Int(1, context.Users.Count()));

            var goalFaker = new Faker<Goal>()
                .RuleFor(g => g.Name, f => f.Commerce.ProductName())
                .RuleFor(g => g.Description, f => f.Lorem.Sentence())
                .RuleFor(g => g.TargetDate, f => f.Date.Between(DateTime.Now, DateTime.Now.AddDays(60)))
                .RuleFor(g => g.UserId, f => f.Random.Int(1, context.Users.Count()))
                .RuleFor(g => g.Status, f => f.PickRandom<Status>());

            var bodyMeasurementFaker = new Faker<BodyMeasurement>()
                .RuleFor(b => b.Weight, f => f.Random.Decimal(50, 250))
                .RuleFor(b => b.Height, f => f.Random.Decimal(150, 220))
                .RuleFor(b => b.BodyFatPercentage, f => f.Random.Int(5, 20))
                .RuleFor(b => b.UserId, f => f.Random.Int(1, context.Users.Count()))
                .RuleFor(b => b.Date, f => f.Date.Between(DateTime.Now.AddDays(-60),DateTime.Now));

            var userData = userFaker.Generate(20);
            context.Users.AddRange(userData);

            var workoutData = workoutFaker.Generate(100);
            context.Workouts.AddRange(workoutData);

            var statisticData = statisticFaker.Generate(300);
            context.Statistics.AddRange(statisticData);

            var goalData = goalFaker.Generate(100);
            context.Goals.AddRange(goalData);

            var bodyMeasurementData = bodyMeasurementFaker.Generate(20);
            context.BodyMeasurements.AddRange(bodyMeasurementData);

            context.SaveChanges();
            return 0;
        }
    }
    

}
