using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(RemoteCompileService1.RemoteCompileService1)))
            {
                host.Open();

                Console.WriteLine("<ENTER> to close host");
                Console.ReadLine();

            }

            


        }
    }
}
