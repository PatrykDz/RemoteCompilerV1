using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            //WAŻNE!!! ŻEBY DZIAŁAŁO, ZMIEŃ IP W app.conf zarówno w projekcie Client, jak i Host!!!
            //NASTĘPNIE... Uruchom Host, i w Service References ->localhost -> Update...

            //PS. ten kod to gówno!!!
            //                              ale działa...(u mnie coś bardzo wolno, z powodu wolnego g++)


            localhost.RemoteCompileService1Client proxy = new Client.localhost.RemoteCompileService1Client();

            Console.WriteLine("1:Commands");
            Console.WriteLine("2:Compiler");
            string choice = Console.ReadLine();

            if (choice == "1")
            {

                Console.WriteLine("<X> or CTRL+C to close client");
                while (true)
                {
                    Console.Write("Plik:");
                    string command = Console.ReadLine();

                    string result = proxy.ExecuteCommand(command);


                    Console.WriteLine(result);
                }

            }
            else
            {
                Console.WriteLine("Scieżka do pliku cpp");
                string sciezka = Console.ReadLine();
                if (File.Exists(sciezka))
                {
                    string filename = Path.GetFileNameWithoutExtension(sciezka);

                    //FileStream kod = File.OpenRead(sciezka);
                    
                    string kod = File.ReadAllText(sciezka);

                    
                    


                    
                    //Console.WriteLine(kod);

                    string result = proxy.Compile(kod, filename);

                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Zla sciezka");
                }
            }



            Console.ReadLine();

        }
    }
}
