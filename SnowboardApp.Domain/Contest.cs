using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardApp.Domain
{
    public class Contest
    {

        public Contest()
        {
            Athletes = new List<AthleteContest>();

        }

public int Id { get; set; }
public DateTime StartDate { get; set; }
public DateTime EndDate { get; set; }
public string EventLocation { get; set; }
public List<AthleteContest> Athletes { get; set; }
public string EventName { get; set; }
public string FirstPlace { get; set; }
public string SecondPlace { get; set; }
public string ThirdPlace { get; set; }

    }
}

