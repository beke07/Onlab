using Microsoft.AspNetCore.Components.Layouts;
using Onlab.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlab.Client.Layouts
{
    public class UserBaseComponent : LayoutComponentBase
    {
        public UserBaseComponent(){ }

        public CurrentUserViewModel User { get; set; }
    }
}
