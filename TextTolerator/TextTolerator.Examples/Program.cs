using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.ArabicRules;
using TextTolerator.Core.Rules.WebsiteRules;
using TextTolerator.Core.RulesProviders;
using TextTolerator.Core.TextToleratorEngines;

internal class Program
{
    private static void Main(string[] args)
    {
        ArabicGenericRulesProvider();
        FixedRulesProvider();
    }

    private static void ArabicGenericRulesProvider()
    {
        //Creating an IRuleProvider that loads all Arabic IRule classes, i.e all IRule classes with ArabicRuleAttribute
        var arabicRulesProvider = new GenericRulesProvider<ArabicRuleAttribute>();

        //Creating the TextToleratorEngine with the Arabic IRulesProvider
        var textToleratorEngine = new TextToleratorEngine(arabicRulesProvider);

        //Setting the example input
        string input = "الإمكانيات";

        //Producing the tolerated list of words
        List<string> output = textToleratorEngine.GetTextToleratorResult(input);

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(String.Join(", ", output));
    }

    private static void FixedRulesProvider()
    {
        //Creating an IRuleProvider that loads 2 specific IRule classes
        var fixedRulesProvider = new FixedRulesProvider(new Website1WWWCleanerTogglerRule(), new Website2HttpCleanerTogglerRule());

        //Creating the TextToleratorEngine with the fixed IRulesProvider
        var textToleratorEngine = new TextToleratorEngine(fixedRulesProvider);

        //Producing the tolerated list of words
        string input = "الإمكَانِياتْ";

        //Producing the tolerated list of words
        List<string> output = textToleratorEngine.GetTextToleratorResult(input);

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(String.Join(", ", output));
    }
}