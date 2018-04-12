using Microsoft.EntityFrameworkCore;
using SnowboardApp.Data;
using SnowboardApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardApp.UI
{
   public class AddUpdateFindDeleteTable
    {
        private static SnowboardAppContext _context = new SnowboardAppContext();

        public static void AddAthletes()
        {
            var _context = new SnowboardAppContext();

            Athlete athlete1 = new Athlete {FirstName = "Ståle", LastName = "Sandbeck", Age = 25, BirthCountry = "Norway"
            };

        Athlete athlete2 = new Athlete { FirstName = "Xavier", LastName = "Delarue", Age = 32, BirthCountry = "France",
            };

            _context.Athletes.AddRange(athlete1, athlete2);
            _context.SaveChanges();
        }
        
        public static void AddContest()
        {
         var _context = new SnowboardAppContext();
            Contest contest1 = new Contest
            {
              
                StartDate = new DateTime(2018-01-12),
                EndDate = new DateTime(2018-01-16),
                EventLocation = "Italy",
                EventName = "Nine Knights",
                FirstPlace = "Ståle Sandbeck",
                SecondPlace = "Mark McMorris",
                ThirdPlace = "Travis Rice"

            };

            _context.Contests.Add(contest1);
            _context.SaveChanges();

        }
  
        public static void AddSnowboard()
        {
            var _context = new SnowboardAppContext();
            Snowboard snowboard1 = new Snowboard

            {
               
                Brand = "Rome",
                Name = "Ståle pro",
                Length = 155,
                AthelteId = 12,
               
            };
            _context.Snowboards.Add(snowboard1);
            _context.SaveChanges();

        }

        public static void AddHomeResort()
        {
            var _context = new SnowboardAppContext();
            HomeResort homeResort1 = new HomeResort
            {
                Name = "Oslo Tryvann Vinterpark",
                Country = "Norway",
                VerticalMeters = 1470

            };

            _context.HomeResorts.Add(homeResort1);
            _context.SaveChanges();
            

        }

        public static void AddAthleteToContest()
        {

            var context = new SnowboardAppContext();
            AthleteContest athleteContest = new AthleteContest
            {
                AthleteId = 3,
                ContestId = 1,

            };

            _context.AthleteContest.Add(athleteContest);
            _context.SaveChanges();
                
        }


        public static void DeleteOne()
        {
            var athlete = _context.Athletes.Find(2);
            
            _context.Athletes.RemoveRange(athlete);
            _context.SaveChanges();


        }

        public static void DeletMany()
        {
            string nameStart = "Mark";
            var athletes = _context.Athletes.Where(m => m.FirstName.StartsWith(nameStart)).ToList();
            _context.Athletes.RemoveRange(athletes);
            _context.SaveChanges();

        }

        public static void DeleteAthleteFromContest()
        {
            var athleteContest = _context.AthleteContest
                    .Where(ac => ac.AthleteId == 3 && ac.ContestId == 1)
                    .FirstOrDefault();
            _context.Remove(athleteContest);
            _context.SaveChanges();

        }


        public static void SelectRawSql()
        {
            string sql = "SELECT * FROM Contests";
            var contests = _context.Contests.FromSql(sql).ToList();
            foreach (var contest in contests)
            {
                Console.WriteLine(contest.EventName);
            }
        }

        public static void SelectRawSqlWithOrderingAndFilter()
        {
            var contests = _context.Contests.FromSql("SELECT * FROM Contests")
                .OrderByDescending(m => m.EventName)
                .Where(m => m.EventName.StartsWith("OS"))
                .ToList();
            foreach (var contest in contests)
            {
                Console.WriteLine(contest.EventName);
            }
        }


        public static void Find()
        {
            var contest1 = _context.Contests.FirstOrDefault(m => m.Id == 6);
            var contest2 = _context.Contests.Find(1);
            Console.WriteLine(contest1.EventName);
            Console.WriteLine(contest2.EventName);

        }

        public static void FindAthleteContest()
        {

            var context = new SnowboardAppContext();
            var contests = context.Contests
                .Include(c => c.Athletes)
                .ThenInclude(ct => ct.Athlete)
                .ToList();

            foreach (var contest in contests)
            {

                Console.WriteLine(contest.EventName);

                foreach (var athlete in contest.Athletes)
                {

                    Console.WriteLine(athlete.Athlete.LastName);
                }
            }
        }

        public static void GetAllAthletes()
        {
            var athletes1 = _context.Athletes.ToList();

            var athletes2 = (from m in _context.Athletes select m.LastName).ToList();
            var athletes3 = _context.Athletes.Where(m => m.LastName.StartsWith("Rice")).ToList();
            string startTitle = "Rice";
            var athletes4 = (from m in _context.Athletes where m.LastName.StartsWith(startTitle) select m).ToList();
            foreach (var athlete in _context.Athletes)
            {
                Console.WriteLine(athlete.LastName);
            }
        }

        public static void Update()
        {

            var contest = _context.Contests.Find(1);
            contest.StartDate = new DateTime(1990, 03, 02);

            _context.Contests.Update(contest);
            _context.SaveChanges();
        }

        public static void UpdateMany() { // FUNKAR EJ, ATHLETE ID ÄR UNIK, LÄGG TILL EN COLUMN I AHTLETECONTEST?
        {

            var context = new SnowboardAppContext();
            string contestEventName = "OS";
            var contests = _context.Contests.Where(c => c.EventName.StartsWith(contestEventName)).ToList();
            contests.ForEach(c => c.StartDate = new DateTime(2018, 04, 11));
            contests.ForEach(c => c.EndDate = new DateTime(2018, 04, 12));
            _context.SaveChanges();

        }


        }



    }
}



