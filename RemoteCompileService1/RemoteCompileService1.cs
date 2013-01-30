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
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in App.config.
    public class RemoteCompileService1 : IRemoteCompileService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string ExecuteCommand(string prog)
        {

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName=prog,
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

        public string Compile(FileStream code, string filename)
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



            //using (FileStream fs = System.IO.File.Create(filepath,(int)code.Length))
            //{
            //   fs.Write(
            //}


            


            FileStream fs = System.IO.File.Create(filepath, (int)code.Length);
            byte[] xcode = new byte[fs.Length];
            fs.Read(xcode, 0, (int)fs.Length);

            fs.Write(xcode, 0, (int)xcode.Length);

            
            




            string arguments = "\"" + filepath + "\"" + " -o " + "\"" + outputfilepath + "\""; // +" 2>" + "\"" + raportpath + "\"";


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









    }
}
