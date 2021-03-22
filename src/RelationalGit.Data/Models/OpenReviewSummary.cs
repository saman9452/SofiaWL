using System;
using System.Collections.Generic;
using System.Text;

namespace RelationalGit.Data.Models
{
    public class OpenReviewSummary
    {
        public long Id { get; set; }

        public DateTime DateTime { get; set; }
        public long SimulationId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public double Average { get; set; }
        public double Median { get; set; }
        public double FirstQu { get; set; }
        public double ThirdQu { get; set; }
        public double Eighty_percentile { get; set; }
        public int EightyPercentileNum { get; set; }
        public int ReviewerNumbers { get; set; }
        public double Eighty_workload { get; set; }
        public double Average_open_review { get; set; }
    }
}
