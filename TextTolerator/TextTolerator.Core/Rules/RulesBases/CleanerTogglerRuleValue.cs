using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTolerator.Core.Rules.RulesBases
{
    public class CleanerTogglerRuleValue
    {
        public string ReplaceFrom { get; }
        public StringPosition Position { get; }

        public CleanerTogglerRuleValue(string replaceFrom, StringPosition position)
        {
            if (position.IsMid())
            {
                throw new ArgumentException("Mid postion is not valid for CleanerTogglerRuleValue", nameof(position));
            }

            ReplaceFrom = replaceFrom;
            Position = position;
        }
    }
}
