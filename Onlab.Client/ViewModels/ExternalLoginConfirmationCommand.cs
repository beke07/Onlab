using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlab.Client.ViewModels
{
    public class ExternalLoginConfirmationCommand
    {
        public string Provider { get; set; }

        public string Email { get; set; }
    }
}
