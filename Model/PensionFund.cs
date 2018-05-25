using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionsConsoleApp.Model
{
    public class PensionFund
    {
        [Key]
        public int PensionNo { get; set; }
        [Write(false)]
        public Employee Employee { get; set; }
        public int AmountContributed { get; set; }
        public DateTime LastContributionDate { get; set; }
    }
}
