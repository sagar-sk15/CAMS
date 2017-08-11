using System.ServiceModel;
using Cams.Domain.Entities.ClientMasters;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices.WcfRequestContext;
using AutoMapper;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class ChargesPayableToService : ServiceBaseReadOnly<ChargesPayableTo, ChargesPayableToDto>, IChargesPayableToService
    {
        public ChargesPayableToService()
        { 
        
        }
        public override ChargesPayableToDto EntityToEntityDto(ChargesPayableTo entity)
        {
            ChargesPayableToDto chargespayabletodto = Mapper.Map<ChargesPayableTo, ChargesPayableToDto>(entity);
            if (entity != null)
            {
                chargespayabletodto.LabourCharges.Clear();
                if (entity.LabourCharges != null)
                {
                    foreach (LabourChargeType LabourCharges in entity.LabourCharges)
                    {
                        LabourChargeTypeDto LabourChargesdto = new LabourChargeTypeDto();
                        LabourChargesdto = Mapper.Map<LabourChargeType, LabourChargeTypeDto>(LabourCharges);
                        chargespayabletodto.LabourCharges.Add(LabourChargesdto);
                    }
                }

                chargespayabletodto.D1LabourCharges.Clear();
                if (entity.D1LabourCharges != null)
                {
                    foreach (LabourChargeType D1LabourCharges in entity.D1LabourCharges)
                    {
                        LabourChargeTypeDto LabourChargesdto = new LabourChargeTypeDto();
                        LabourChargesdto = Mapper.Map<LabourChargeType, LabourChargeTypeDto>(D1LabourCharges);
                        chargespayabletodto.D1LabourCharges.Add(LabourChargesdto);
                    }
                }

                chargespayabletodto.D2LabourCharges.Clear();
                if (entity.D2LabourCharges != null)
                {
                    foreach (LabourChargeType D2LabourCharges in entity.D2LabourCharges)
                    {
                        LabourChargeTypeDto LabourChargesdto = new LabourChargeTypeDto();
                        LabourChargesdto = Mapper.Map<LabourChargeType, LabourChargeTypeDto>(D2LabourCharges);
                        chargespayabletodto.D2LabourCharges.Add(LabourChargesdto);
                    }
                }
            }
            return chargespayabletodto;
        }
        public override ChargesPayableTo EntityDtoToEntity(ChargesPayableToDto entityDto)
        {
            ChargesPayableTo chargespayableto = Mapper.Map<ChargesPayableToDto, ChargesPayableTo>(entityDto);
            if (entityDto != null)
            {
                chargespayableto.LabourCharges.Clear();
                if (entityDto.LabourCharges != null)
                {
                    foreach (LabourChargeTypeDto LabourCharges in entityDto.LabourCharges)
                    {
                        LabourChargeType LabourChargesdto = new LabourChargeType();
                        LabourChargesdto = Mapper.Map<LabourChargeTypeDto,LabourChargeType>(LabourCharges);
                        chargespayableto.LabourCharges.Add(LabourChargesdto);
                    }
                }

                chargespayableto.D1LabourCharges.Clear();
                if (entityDto.D1LabourCharges != null)
                {
                    foreach (LabourChargeTypeDto D1LabourCharges in entityDto.D1LabourCharges)
                    {
                        LabourChargeType LabourChargesdto = new LabourChargeType();
                        LabourChargesdto = Mapper.Map<LabourChargeTypeDto, LabourChargeType>(D1LabourCharges);
                        chargespayableto.D1LabourCharges.Add(LabourChargesdto);
                    }
                }

                chargespayableto.D2LabourCharges.Clear();
                if (entityDto.D2LabourCharges != null)
                {
                    foreach (LabourChargeTypeDto D2LabourCharges in entityDto.D2LabourCharges)
                    {
                        LabourChargeType LabourCharges = new LabourChargeType();
                        LabourCharges = Mapper.Map<LabourChargeTypeDto, LabourChargeType>(D2LabourCharges);
                        chargespayableto.D2LabourCharges.Add(LabourCharges);
                    }
                }
            }
            return chargespayableto;
        }
    }
}
