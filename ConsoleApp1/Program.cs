using Microsoft.EntityFrameworkCore;
using SnowboardApp.Data;
using SnowboardApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SnowboardApp.UI
{
   public class SingleObjectModifiaction
    {
    
        static void Main(string[] args)
        {
            //AddToTable.AddAthlete();
            //AddToTable.AddSnowboard();
            //AddToTable.AddContest();
            //AddToTable.AddHomeResort();
            //AddToTable.DeleteOne();
            //AddToTable.DeletMany();
            //AddToTable.AddAthletes();
            //AddSnowboardToAthelte();
            //AddManyToManyObject();
            //AddToTable.Find();
            //AddToTable.SelectRawSql();
            //AddToTable.GetAllAthletes();           
            //AddToTable.SelectRawSqlWithOrderingAndFilter();
            //AddToTable.Update();
            //AddToTable.UpdateMany();
            //AddToTable.AddAthleteToContest();
            //AddToTable.DeleteAthleteFromContest();
            //AddToTable.FindAthleteContest();

            //var result = ShowFirstAthelte();
            //Console.WriteLine("WAIT A SECOND");
            //Console.WriteLine(result.Result.LastName);

            //Jag valde att använda Async för att jag tycker att man har bättre kontroll över flödet då det är lättare att se när en specifik task skall köras.
            //Det verkar också som Async används mer, kanske för att det minskar risken för race conditions

        }

        private static void AddSnowboardToAthelte()
        {
            var context = new SnowboardAppContext();
            var snowboard = new Snowboard { Brand = "Rome", Length = 150, Name = "SKS", AthelteId = 14 };
            context.Add(snowboard);
            context.SaveChanges();

            var snowboard1 = new Snowboard { Brand = "Brädan1337", Length = 1337, Name = "ELIT", AthelteId = 14 };
            context.Add(snowboard1);
            context.SaveChanges();

        }

        private static void AddManyToManyObject()
        {
            var context = new SnowboardAppContext();
            var athlete = new Athlete { FirstName = "Torsten", LastName = "Horgmo", Age = 28, BirthCountry = "Norway",};
            var contest = context.Contests.Find(1);
            context.Add(athlete);
            context.Add(new AthleteContest { Athlete = athlete, Contest = contest });
            context.SaveChanges();
        }

        public static void AddAthleteHomeResort()
        {
            var context = new SnowboardAppContext();
            AthleteHomeResort athleteHomeResort1 = new AthleteHomeResort()
            {
                AthleteId = 1,
                HomeResortId = 1

            };

            context.AthleteHomeResort.Add(athleteHomeResort1);
            context.SaveChanges();
        }

        // Visar upp den första athelten som finns i databasen.

        public static async Task<Athlete> ShowFirstAthelte()
        {
            var cont = new SnowboardAppContext();
            var result = await cont.Athletes.FirstAsync<Athlete>();
            return result;
        }
    }

  }
    

