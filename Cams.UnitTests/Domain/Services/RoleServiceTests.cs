using System;
using System.Linq;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Data;


namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class RoleServiceTests : CamsTestBase
    {
        public IRoleService RoleService { get; set; }
        public RoleDto RoleInstance { get; set; }
        
        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.RoleService = ClientServiceLocator.Instance().ContractLocator.RoleServices;
        }

        //[DataSource("SqlClientDataSource")]
        [TestMethod]
        public virtual void GetRoleById() 
        {
            //DbCommand command = null;
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "dbo.SPCreateRole";            
            var id = 1;
            //var id = RoleInstance.RoleId;
            var result = RoleService.GetById(id);
        }

        [TestMethod]
        public virtual void FindAll()
        {
            GetRoleById();
            var result = this.RoleService.FindAll();
        }
    }
}
