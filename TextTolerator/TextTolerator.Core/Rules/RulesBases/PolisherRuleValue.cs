using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTolerator.Core.Rules.RulesBases
{
    public class PolisherRuleValue
    {
        public string ReplaceFrom { get; }
        public StringPosition Position { get; }

        public PolisherRuleValue(string replaceFrom, StringPosition position)
        {
            ReplaceFrom = replaceFrom;
            Position = position;
        }
    }
}
