using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace RemoteCompileService1
{
    //WAŻNE!!! ŻEBY DZIAŁAŁO, ZMIEŃ IP W app.conf zarówno w projekcie Client, jak i Host!!!
    //NASTĘPNIE... Uruchom Host, i w Service References ->localhost -> Update...

    //PS. ten kod to gówno!!!
    //                              ale działa...(u mnie coś bardzo wolno, z powodu wolnego g++)


    public class RemoteCompileService1 : IRemoteCompileService1
    {
        public string GetData(int value)//Przykładowa funkcja wygenerowana automatycznie, nie potrzebna
        {
            return string.Format("You entered: {0}", value);
        }

        public string ExecuteCommand(string prog)
        {
            //Pozwala na uruchamianie zdalne komend, np. ipconfig


            var polecenie = prog.Split(' ');


            
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName=polecenie[0],
               // Arguments = polecenie[1],
                RedirectStandardOutput = true,
                UseShellExecute = false

            };

            try
            {
                Process p = Process.Start(psi);
                string result = p.StandardOutput.ReadToEnd();

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string Compile(string code, string filename)
        {

            string fexe = filename + ".exe";
            string fcpp = filename + ".cpp";

            string directory = Directory.GetCurrentDirectory()+@"\CompilerWorkSpace\";

            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                return directory;
            }


            string filepath = directory + fcpp;
            string outputfilepath = directory + fexe;

            string main_raport_path = directory + "main_raport.txt";


            File.WriteAllText(filepath, code);


            //using (FileStream fs = System.IO.File.Create(filepath,(int)code.Length))
            //{
            //   fs.Write(
            //}


            


            //FileStream fs = System.IO.File.Create(filepath, (int)code.Length);
            //byte[] xcode = new byte[fs.Length];
            //fs.Read(xcode, 0, (int)fs.Length);

            //fs.Write(xcode, 0, (int)xcode.Length);

            
            //Nie działa z FileStream :(




            string arguments = "\"" + filepath + "\"" + " -o " + "\"" + outputfilepath + "\"";   // +" 2>" + "\"" + raportpath + "\""; 


            ProcessStartInfo csi = new ProcessStartInfo
            {
                FileName = "g++",
                WorkingDirectory=directory,
                Arguments = fcpp + " -o "+fexe,
                RedirectStandardOutput = true,
                UseShellExecute = false

            };

            Process c = Process.Start(csi);
            c.WaitForExit();
            string gppoutput = c.StandardOutput.ReadToEnd();
            //Tu jest problem, g++ nie daje nic do zmiennej gppoutput





            //Prowizoryczne generowanie raportów(straszne...ale działa)
            if (!File.Exists(outputfilepath))
            {
                string error = "Kompilacja pliku nie powiodła się!!!";
                string cur_raport = string.Format("{0}{0}=============" + fexe + "============{0}{0}" + DateTime.Now + "{0}{0}" + error + "{0}{0}===================================", Environment.NewLine);
                File.AppendAllText(main_raport_path, cur_raport);

                return error;
            }
            else
            //FILE EXISTS
            {


                ProcessStartInfo exe = new ProcessStartInfo
                {
                    FileName = outputfilepath,
                    RedirectStandardOutput = true,
                    UseShellExecute = false

                };


                Process e = Process.Start(exe);
                string result = e.StandardOutput.ReadToEnd();


                //ADDING TO RAPORT
                string cur_raport = string.Format("{0}{0}=============" + fexe + "============{0}{0}" + DateTime.Now + "{0}{0}" + result + "{0}{0}===================================", Environment.NewLine);


                File.AppendAllText(main_raport_path, cur_raport);

                return result;

            }
        }





        //To już jest koniec...
        
    }
}
