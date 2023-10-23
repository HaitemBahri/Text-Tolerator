using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.WebsiteRules;

namespace TextTolerator.Core.Tests.RulesTests.WebsiteRulesTests
{
    public class WebsiteWWWCleanerTogglerRuleTests
    {
        private WebsiteWWWCleanerTogglerRule _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"www.google.com", new List<string>(){ "www.google.com", "google.com" }, ""},
            {"google.com", new List<string>(){ "google.com", "www.google.com"}, ""},

            {"www.google.com/maps", new List<string>(){ "www.google.com/maps", "google.com/maps" }, ""},
            {"google.com/maps", new List<string>(){ "google.com/maps", "www.google.com/maps"}, ""},

            {"WWW.GOOGLE.COM", new List<string>(){ "WWW.GOOGLE.COM", "GOOGLE.COM" }, ""},
            {"GOOGLE.COM", new List<string>(){ "GOOGLE.COM", "WWW.GOOGLE.COM"}, ""},

            {"WWW.GOOGLE.COM/MAPS", new List<string>(){ "WWW.GOOGLE.COM/MAPS", "GOOGLE.COM/MAPS" }, ""},
            {"GOOGLE.COM/MAPS", new List<string>(){ "GOOGLE.COM/MAPS", "WWW.GOOGLE.COM/MAPS"}, ""},

            {"GOOGLE/MAPSقوقل", new List<string>(){ "GOOGLE/MAPSقوقل"}, ""},
            {"GOOGLE.COM MAPS", new List<string>(){ "GOOGLE.COM MAPS",}, ""},
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectResultTheoryData))]
        public void ShouldReturnCorrectResult(string input, List<string> expectedResult, string testDataName)
        {
            var actualResult = _sut.ProcessText(input);

            expectedResult.Sort();
            actualResult.Sort();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
