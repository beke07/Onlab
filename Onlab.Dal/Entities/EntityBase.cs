using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlab.Dal.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public IdentityUser Creator { get; set; }
    }
}
