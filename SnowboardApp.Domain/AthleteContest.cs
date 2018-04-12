using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardApp.Domain
{
    // För att se vilka tävlingar atleterna tävlade i

    public class AthleteContest
    {
        public int AthleteId { get; set; }
        public int ContestId { get; set; }

        public Athlete Athlete { get; set; }
        public Contest Contest { get; set; }
    }
}
