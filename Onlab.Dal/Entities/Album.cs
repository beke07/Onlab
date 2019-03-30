using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlab.Dal.Entities
{
    public class Album : EntityBase
    {
        public ApplicationUser User { get; set; }

        public string Name { get; set; }

        public IList<Image> Images { get; set; }
    }
}
