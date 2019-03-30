using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlab.Dal.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(){ }
    }
}
