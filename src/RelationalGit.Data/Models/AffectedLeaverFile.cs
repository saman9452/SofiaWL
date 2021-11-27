using System;
using System.Collections.Generic;
using System.Text;

namespace RelationalGit.Data
{
    
        public class AffectedLeaverFile
        {

            public long Id { get; set; }


            public long SimulationId { get; set; }
            public long PullRequestId { get; set; }
            public string FilePath { get; set; }



        }
    

}
