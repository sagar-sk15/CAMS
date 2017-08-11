using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Domain.Entities.ClientMasters;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto.User;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;
using Cams.Common.Querying;
using Cams.Common;
namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class UnitTest1 : CamsTestBase
    {
        public ILabourChargeTypeService LabourChargeTypeService { get; set; }
        public IUserService UserService { get; set; }
        public IChargesPayableToService ChargesPayableToService { get; set; }
        public IMeasuringUnitService MeasuringUnitService { get; set; }

        public UserDto CurrentUserInstance { get; set; }
        public LabourChargeTypeDto LabourChargeInstance { get; set; }
        public MeasuringUnitDto MeasuringUnitInstance { get; set; }

        long SuperAdminId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.LabourChargeTypeService = ClientServiceLocator.Instance().ContractLocator.LabourChargeTypeServices;
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.ChargesPayableToService = ClientServiceLocator.Instance().ContractLocator.ChargesPayableToServices;
            this.MeasuringUnitService = ClientServiceLocator.Instance().ContractLocator.MeasuringUnitServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
        }

        [TestMethod]
        public virtual void CreateLabourCharge()
        {
            var LabourChargeTypedto = new LabourChargeTypeDto
            {
                LabourCharge = "Kata1234",
                CAId = 1,
                CreatedBy = -1,
                ModifiedBy = -1
            };
            this.LabourChargeInstance = this.LabourChargeTypeService.Create(LabourChargeTypedto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.LabourChargeInstance.LabourChargeId == 0, "LabourChargeId should have been updated");
            Assert.AreEqual(this.LabourChargeInstance.LabourCharge, LabourChargeTypedto.LabourCharge, "LabourCharge are different");
        }

        [TestMethod]
        public virtual void UpdateLabourCharge()
        {
            var LabourChargeTypedto = new LabourChargeTypeDto
            {
                LabourChargeId = 1,
                LabourCharge = "hamali",
                CAId = 1,
                CreatedBy = -1,
                ModifiedBy = -1
            };
            this.LabourChargeInstance = this.LabourChargeTypeService.Update(LabourChargeTypedto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.LabourChargeInstance.LabourChargeId == 0, "LabourChargeId should have been updated");
            Assert.AreEqual(this.LabourChargeInstance.LabourCharge, LabourChargeTypedto.LabourCharge, "LabourCharge are different");
        }

        [TestMethod]
        public virtual void FindLabourChargeTypesOnCAId()
        {
            int CAId = 1;
            Query query = new Query();
            Criterion criteriaCAId = new Criterion(Constants.CAID, CAId, CriteriaOperator.Equal);
            query.Add(criteriaCAId);

            var result = this.LabourChargeTypeService.FindByQuery(query);
            Assert.IsTrue(result.Entities.Count > 0, "Labour Charge Types found");
        }

        [TestMethod]
        public virtual void FindAllChargesPayableTo()
        {
            var result = this.ChargesPayableToService.FindAll();
            Assert.IsTrue(result.Entities.Count > 0, "Labour Charge Types found");
        }

        [TestMethod]
        public virtual void CreateMeasuringUnit()
        {
            var measuringunitdto = new MeasuringUnitDto
            {
                UnitType = Common.UnitType.Weight,
                MeasurementUnit = "Quintal",
                EquivalentUnit = "100",
                CAId = 1,
                CreatedBy = 1,
                ModifiedBy = 1
            };
            this.MeasuringUnitInstance = this.MeasuringUnitService.Create(measuringunitdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.MeasuringUnitInstance.UnitId == 0, "UnitId should have been updated");
            Assert.AreEqual(this.MeasuringUnitInstance.MeasurementUnit, MeasuringUnitInstance.MeasurementUnit, "Measuring Units are different");
        }

        [TestMethod]
        public virtual void FindMeasuringUnitOnCAId()
        {
            Query query = new Query();
            Criterion criteriaCAId = new Criterion(Constants.CAID, 1, CriteriaOperator.Equal);
            Criterion criteriaUnitType = new Criterion(Constants.UNITTYPE, Common.UnitType.Weight, CriteriaOperator.Equal);
            query.Add(criteriaCAId);
            query.Add(criteriaUnitType);
            query.QueryOperator = QueryOperator.And;
            var result = this.MeasuringUnitService.FindByQuery(query);
            Assert.IsTrue(result.Entities.Count > 0, "Measuring Unit Charge Types found");          
        }
    }
}
