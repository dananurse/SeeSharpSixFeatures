using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpSixFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer c0 = null;
            DoTest(c0);

            IContainer c1 = new Container();
            DoTest(c1);

            IContainer c2 = new Container();
            c2.Contents = new List<string>();
            DoTest(c2);

            IContainer c3 = new Container();
            c3.Contents = new List<string> {"Value1"};
            DoTest(c3);

            Pause();
        }

        private static void DoTest(IContainer item)
        {
            Console.WriteLine($"V1 [{IsValidV1(item)}] : V2 [{IsValidV2(item)}]");
        }

        static bool IsValidV1(IContainer item)
        {
            return item != null &&
                   item.Contents != null &&
                   item.Contents.Any();
        }

        static bool IsValidV2(IContainer item)
        {
            return item?.Contents?.Any() ?? false;
        }

        private static void Pause()
        {
            Console.ReadKey();
        }
    }

    public interface IContainer
    {
        List<string> Contents { get; set; }
    }

    public class Container : IContainer
    {
        public List<string> Contents { get; set; }
    }
}
