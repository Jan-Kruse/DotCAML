using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAML
{
    public class Aggregation
    {
        public AggregationType Type { get; set; }

        public string Name { get; set; }
    }

    public enum AggregationType
    {
        Count,
        Sum,
        Avg,
        Max,
        Min,
        Stdev,
        Var
    }
}
