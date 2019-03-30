using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlab.Shared
{
    public class CurrentUser
    {
        public bool IsSignedIn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
