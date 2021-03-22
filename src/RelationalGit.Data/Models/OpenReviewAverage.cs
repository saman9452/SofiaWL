using System;
using System.Collections.Generic;
using System.Text;

namespace RelationalGit.Data.Models
{
    public class OpenReviewAverage
    {

        public long Id { get; set; }


        public long SimulationId { get; set; }
        public long PeriodId { get; set; }
        public double MaxAverage { get; set; }
        public double MinAverage { get; set; }
        public double Average { get; set; }
        public double Median { get; set; }
        public double FirstQu { get; set; }
        public double ThirdQu { get; set; }
        public double Eighty_percentile { get; set; }
        public double EightyPercentileNum { get; set; }

        public double ReviewerNumbers { get; set; }
        public double Eighty_workload { get; set; }
        public double Open_Review { get; set; }
    }
}
