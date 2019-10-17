using System;

namespace Ninja
{
    class Program
    {
        static void Main(string[] args)
        {

            var service = new VideoService();
            var title = service.ReadVideoTitle();

            Console.WriteLine("title of file is: " + title);
        }
    }
}
