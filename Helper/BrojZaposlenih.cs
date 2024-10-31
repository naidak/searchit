using JobSearchingWebApp.Helper;

namespace JobSearchingWebApp.Helper
{
    public enum BrojZaposlenih
    {
        _1_10,
        _11_50,
        _51_100,
        _101_500,
        _501_1000,
        _1001_5000,
        _5001_10000,
        _10001_plus
    }

    public static class BrojZaposlenihExtensions
    {
        public static string ToDisplayString(this BrojZaposlenih range)
        {
            return range switch
            {
                BrojZaposlenih._1_10 => "1-10",
                BrojZaposlenih._11_50 => "11-50",
                BrojZaposlenih._51_100 => "51-100",
                BrojZaposlenih._101_500 => "101-500",
                BrojZaposlenih._501_1000 => "501-1000",
                BrojZaposlenih._1001_5000 => "1001-5000",
                BrojZaposlenih._5001_10000 => "5001-10000",
                BrojZaposlenih._10001_plus => "10001+",
                _ => "Unknown",
            };
        }

        public static List<string> GetAllEmployeeCountRanges()
        {
            return Enum.GetValues(typeof(BrojZaposlenih))
                       .Cast<BrojZaposlenih>()
                       .Select(e => e.ToDisplayString())
                       .ToList();
        }
    }
}