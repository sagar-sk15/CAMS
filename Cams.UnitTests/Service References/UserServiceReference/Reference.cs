﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cams.UnitTests.UserServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Cams/userservices/", ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Cams/userservices/IUserService/GetById", ReplyAction="http://Cams/userservices/IUserService/GetByIdResponse")]
        Cams.Common.Dto.User.UserDto GetById(long id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Cams/userservices/IUserService/Update", ReplyAction="http://Cams/userservices/IUserService/UpdateResponse")]
        Cams.Common.Dto.User.UserDto Update(Cams.Common.Dto.User.UserDto user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Cams/userservices/IUserService/Create", ReplyAction="http://Cams/userservices/IUserService/CreateResponse")]
        Cams.Common.Dto.User.UserDto Create(Cams.Common.Dto.User.UserDto User);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Cams/userservices/IUserService/FindAll", ReplyAction="http://Cams/userservices/IUserService/FindAllResponse")]
        Cams.Common.Dto.EntityDtos<Cams.Common.Dto.User.UserDto> FindAll();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : Cams.UnitTests.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<Cams.UnitTests.UserServiceReference.IUserService>, Cams.UnitTests.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Cams.Common.Dto.User.UserDto GetById(long id) {
            return base.Channel.GetById(id);
        }
        
        public Cams.Common.Dto.User.UserDto Update(Cams.Common.Dto.User.UserDto user) {
            return base.Channel.Update(user);
        }
        
        public Cams.Common.Dto.User.UserDto Create(Cams.Common.Dto.User.UserDto User) {
            return base.Channel.Create(User);
        }
        
        public Cams.Common.Dto.EntityDtos<Cams.Common.Dto.User.UserDto> FindAll() {
            return base.Channel.FindAll();
        }
    }
}
