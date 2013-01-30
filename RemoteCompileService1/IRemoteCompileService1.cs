using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace RemoteCompileService1
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in App.config.
    [ServiceContract(Namespace="http://remotecompiler")]
    public interface IRemoteCompileService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string ExecuteCommand(string prog);

        [OperationContract]
        string Compile(string code, string filename);


        // TODO: Add your service operations here
    }


}
