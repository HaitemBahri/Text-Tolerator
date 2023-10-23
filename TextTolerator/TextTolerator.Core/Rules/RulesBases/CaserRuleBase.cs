using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTolerator.Core.Rules.RulesBases
{
    public class CaserRuleBase : IRule
    {
        public List<string> ProcessText(string inputText)
        {
            List<string> results = new List<string>();

            var lowerCaseResult = inputText.ToLower();
            results.Add(lowerCaseResult);

            var capCaseResult = inputText[0].ToString().ToUpper() + inputText.AsSpan(1).ToString().ToLower();
            results.Add(capCaseResult);

            var upperCaseResult = inputText.ToUpper();
            results.Add(upperCaseResult);

            if (results.Contains(inputText))
            {
                results.Remove(inputText);
            }

            results.Add(inputText);

            return results;
        }
    }
}
