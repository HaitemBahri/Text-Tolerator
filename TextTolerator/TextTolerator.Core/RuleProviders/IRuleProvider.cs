using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules;

namespace TextTolerator.Core.RuleProviders
{
    public interface IRuleProvider
    {
        IEnumerable<IRule> GetRules();
    }
}
