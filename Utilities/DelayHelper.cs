using System.Threading;

namespace Lab8.Utilities
{
    public class DelayHelper
    {
        public static void Sleep(int milliseconds = 1000)
        {
            Thread.Sleep(milliseconds);
        }
    }
}