﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5466
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.localhost {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://remotecompiler", ConfigurationName="localhost.IRemoteCompileService1")]
    public interface IRemoteCompileService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://remotecompiler/IRemoteCompileService1/GetData", ReplyAction="http://remotecompiler/IRemoteCompileService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://remotecompiler/IRemoteCompileService1/ExecuteCommand", ReplyAction="http://remotecompiler/IRemoteCompileService1/ExecuteCommandResponse")]
        string ExecuteCommand(string prog);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://remotecompiler/IRemoteCompileService1/Compile", ReplyAction="http://remotecompiler/IRemoteCompileService1/CompileResponse")]
        string Compile(string code, string filename);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IRemoteCompileService1Channel : Client.localhost.IRemoteCompileService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class RemoteCompileService1Client : System.ServiceModel.ClientBase<Client.localhost.IRemoteCompileService1>, Client.localhost.IRemoteCompileService1 {
        
        public RemoteCompileService1Client() {
        }
        
        public RemoteCompileService1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RemoteCompileService1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RemoteCompileService1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RemoteCompileService1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public string ExecuteCommand(string prog) {
            return base.Channel.ExecuteCommand(prog);
        }
        
        public string Compile(string code, string filename) {
            return base.Channel.Compile(code, filename);
        }
    }
}
