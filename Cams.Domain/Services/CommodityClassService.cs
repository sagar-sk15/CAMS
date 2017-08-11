using System.ServiceModel;
using Cams.Domain.Entities.ClientMasters;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices.WcfRequestContext;
using AutoMapper;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class CommodityClassService : ServiceBaseReadOnly<CommodityClass, CommodityClassDto>, ICommodityClassService
    {
        public CommodityClassService()
        {
        }

        #region Override the base abstract methods

        public override CommodityClass EntityDtoToEntity(CommodityClassDto entityDto)
        {
            CommodityClass commodityclass = Mapper.Map<CommodityClassDto, CommodityClass>(entityDto); 
            if (entityDto != null)
            {
                //#region Commodities
                //commodityclass.Commodities.Clear();
                //if (entityDto.Commodities != null)
                //{
                //    CommodityService commodityService = new CommodityService();
                //    foreach (CommodityDto commodityDto in entityDto.Commodities)
                //    {
                //        Commodity commodity = commodityService.EntityDtoToEntity(commodityDto);
                //        commodityclass.Commodities.Add(commodity);
                //    }
                //}
                //#endregion 

                //#region CommoditiesofClients
                //commodityclass.CommoditiesofClients.Clear();
                //if(entityDto.CommoditiesofClients != null)
                //{
                //    ClientService clientService = new ClientService();
                //    foreach (ClientDto clientDto in entityDto.CommoditiesofClients)
                //    {
                //        Client client = clientService.EntityDtoToEntity(clientDto);
                //        commodityclass.CommoditiesofClients.Add(client);
                //    }
                //}
                //#endregion
            }
            return commodityclass;
        }

        public override CommodityClassDto EntityToEntityDto(CommodityClass entity)
        {
            CommodityClassDto commodityclassDto = Mapper.Map<CommodityClass, CommodityClassDto>(entity);
            if (entity != null)
            {
                //#region Commodities
                //commodityclassDto.Commodities.Clear();
                //if(entity.Commodities != null)
                //{
                //    CommodityService commodityService = new CommodityService();
                //    foreach (Commodity commodity in entity.Commodities)
                //    {
                //        CommodityDto commodityDto = commodityService.EntityToEntityDto(commodity);
                //        commodityclassDto.Commodities.Add(commodityDto);
                //    }
                //}
                //#endregion
                
                //#region CommoditiesofClients
                //commodityclassDto.CommoditiesofClients.Clear();
                //if (entity.CommoditiesofClients != null)
                //{
                //    ClientService clientService = new ClientService();
                //    foreach (Client client in entity.CommoditiesofClients)
                //    {
                //        ClientDto clientDto = clientService.EntityToEntityDto(client);
                //        commodityclassDto.CommoditiesofClients.Add(clientDto);
                //    }
                //}
                //#endregion
            }
            return commodityclassDto;
        }
        #endregion 
    }
}
