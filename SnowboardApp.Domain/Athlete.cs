using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardApp.Domain
{
    public class Athlete 
    {
        public Athlete ()
        {

            Contests = new List<AthleteContest>();

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string BirthCountry { get; set; }
        public List<AthleteContest> Contests { get; set; }
        
    }

}
    
