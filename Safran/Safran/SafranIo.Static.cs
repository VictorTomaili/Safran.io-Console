
using SafranConsole.Safran.Rss;

namespace SafranConsole.Safran
{
    public partial class Safran
    {
        static Safran()
        {
            io = new Safran(new SafranRss());
        }

        public static Safran io { get; set; }
    }
}