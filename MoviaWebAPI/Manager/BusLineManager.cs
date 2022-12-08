using MoviaWebAPI.Models;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

namespace MoviaWebAPI.Manager
{
    public class BusLineManager
    {
        public static List<BusLine> BusLines = new List<BusLine>()
        {
            new BusLine("1A",DateTime.Now,"This is a mockup message"),
            new BusLine("1A",DateTime.Now.AddDays(1),"mockup 2"),
            new BusLine("1A",DateTime.Now.AddDays(2),"mockup 3"),
            new BusLine("2A",DateTime.Now,"Test message")
        };
        public List<string> Get(string line,int amount)
        {
            /*Hente beskeder ud fra Line og amount
             * Sorter listen efter seneste tidsstempel
             * Return beskeder
             */
            List<string> messages = new List<string>();
            messages = (List<string>)BusLines
                .Where(x => x.Line == line)
                .Take(amount)
                .OrderByDescending(y=> y.Time)
                .Select(f=>f.Message)
                .ToList();

            return messages;
        }
        public List<string> Get(DateTime from, DateTime to)
        {
            List<string> messages = new List<string>();
            messages = BusLines
                .Where(x=> x.Time >= from && x.Time <= to)
                .OrderByDescending(x => x.Time)
                .Select(x=> x.Message)
                .ToList();
            return messages;
        }

        public BusLine Post(BusLine value)
        {
            BusLines.Add(value);
            return value;
        }
    }
}
