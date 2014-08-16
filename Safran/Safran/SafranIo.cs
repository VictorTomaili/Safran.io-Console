
using System.Collections.Generic;

namespace SafranConsole.Safran
{
    public class SafranIo
    {
        public static IEnumerable<string> GetHeaderList()
        {
            return new List<string>() {"Hello Safran", "Safran Console"};
        }
    }
}