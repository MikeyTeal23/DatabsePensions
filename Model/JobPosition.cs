using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionsConsoleApp.Model
{
    public class JobPosition
    {
        [Key]
        public int JobNo { get; set; }
        public string JobPositionName { get; set; }
    }
}
