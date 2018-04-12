using Microsoft.EntityFrameworkCore;
using SnowboardApp.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace SnowboardApp.Data
{
    public class SnowboardAppContext : DbContext

    {
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<AthleteContest> AthleteContest { get; set; }
        public DbSet<AthleteHomeResort> AthleteHomeResort { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<HomeResort> HomeResorts { get; set; }
        public DbSet<Snowboard> Snowboards { get; set; }

        public static readonly LoggerFactory SnowboardLoggerFactory  
                = new LoggerFactory(new[] {
                           new ConsoleLoggerProvider ((category, level)
                        => category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information, true)
                });



       // KVAR ATT GÖRA Med hjälp av kod kunna lägga till, läsa in, ändra och radera poster i databasen med hjälp av Entity Framework
       // Med kod lägga till, läsa in och uppdatera poster i kopplade tabeller med en 0,1-* och*-* relation
       //Mot minst en tabell visa att ni kan arbeta asynkront/trådat och i en kommentar motivera varför ni valt den teknik ni har valt


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unik kombination
            modelBuilder.Entity<AthleteContest>().HasKey(m => new { m.AthleteId, m.ContestId });
            // Unik kombination
            modelBuilder.Entity<AthleteHomeResort>().HasKey(a => new { a.AthleteId, a.HomeResortId });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(SnowboardLoggerFactory)
            .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SnowboardAppDb; Trusted_Connection = True;");
            



        }
        

    }
}   
