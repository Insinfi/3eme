using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_is_love
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] readBuffer;
            var MyStream = File.OpenRead(@"C:\Program Files (x86)\Android\android-sdk\platforms\android-23\data\layoutlib.jar");
            readBuffer = new byte[MyStream.Length];
            MyStream.ReadAsync(readBuffer, 0, (int)MyStream.Length).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("{0} bytes lus avec succès", task.Result);
                }
                MyStream.Dispose();
            });
            Console.ReadKey();
        }
    }
}



