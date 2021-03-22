using System;
using System.Collections.Generic;
using System.Text;

namespace RelationalGit.Data.Models
{
    public class DeveloperOpenReview
    {
        public long Id { get; set; }
        public string NormalizedName { get; set; }
        public long SimulationId { get; set; }
        public int OpenReviews { get; set; }
        public DateTime DateTime { get; set; }
        public string PullRequests { get; set; }
    }
}
