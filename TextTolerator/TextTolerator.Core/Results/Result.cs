
namespace TextTolerator.Core.Results
{
    public class Result
    {
        private List<string> result = new List<string>();

        public Result(string originalText)
        {
            AddToResultList(originalText);
        }

        public void AddToResultList(params string[] values)
        {
            result.AddRange(values);

            //TODO: find a better way to make sure you are not adding duplicates, instead of using .Distinct()
            result = result.Distinct().ToList();
        }

        public string[] GetResultArray()
        {
            return result.AsReadOnly().ToArray();
        }
    }
}
