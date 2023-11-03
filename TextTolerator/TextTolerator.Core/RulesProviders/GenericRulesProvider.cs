using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules;

namespace TextTolerator.Core.RulesProviders
{
    public class GenericRulesProvider<T> : IRulesProvider where T : RuleAttribute
    {
        public IEnumerable<IRule> GetRules()
        {
            var attribu = from assemblies in AppDomain.CurrentDomain.GetAssemblies()
                          from type in assemblies.GetTypes()
                          where type.GetCustomAttributes(typeof(T), true).Length > 0
                          select type;

            var rules = from attribute in attribu
                        let rule = Activator.CreateInstance(attribute)
                        where rule != null
                        select (IRule)rule;

            return rules;
        }
    }
}
