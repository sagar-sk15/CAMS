using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Logging;
using Cams.Domain.Repository;
using Cams.Domain.TransManager;
using Cams.Domain.AppServices;
using AutoMapper;
using Cams.Common.Dto;
using Cams.Common.Message;
using Cams.Common.Querying;

namespace Cams.Domain.Services
{
    public abstract class ServiceBaseReadOnly<TEntity, TEntityDto>
    {
        protected TResult ExecuteCommand<TResult>(Func<IRepositoryLocator, TResult> command)
        {
            using(ITransManager manager = Container.GlobalContext.TransFactory.CreateManager())
            {
                return manager.ExecuteCommand(command);
            }
        }

        #region Implementation of ITEntityService

        public TEntityDto GetById(long id)
        {
            LoggingFactory.LogInfo("Invoked GetById for " +typeof(TEntity).Name+" : Id :" + id);
            //return ExecuteCommand(loc => EntityToEntityDto(loc.GetById<TEntity>(id)));
            var result = ExecuteCommand(loc => EntityToEntityDto(loc.GetById<TEntity>(id)));
            if (result == null)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, typeof(TEntity).Name + " with id:" + id + " not found");
            return result;
        }

        public TEntityDto GetById(int id)
        {
            LoggingFactory.LogInfo("Invoked GetById for " + typeof(TEntity).Name + " : Id : " + id);
            //return ExecuteCommand(loc => EntityToEntityDto(loc.GetById<TEntity>(id)));
            var result = ExecuteCommand(loc => EntityToEntityDto(loc.GetById<TEntity>(id)));
            if (result == null)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, typeof(TEntity).Name + " with id:" + id + " not found");
            return result;
        }

        public EntityDtos<TEntityDto> FindAll()
        {
            LoggingFactory.LogInfo("Invoked FindAll for " + typeof(TEntity).Name);
            return ExecuteCommand(FindAllCommand);
        }

        public EntityDtos<TEntityDto> FindByQuery(Query query)
        {
            LoggingFactory.LogInfo("Invoked FindAll for " + typeof(TEntity).Name);
            return ExecuteCommand(locator => FindByQueryCommand(locator, query));
        }

        public EntityDtos<TEntityDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            LoggingFactory.LogInfo("Invoked FindAll for " + typeof(TEntity).Name);
            return ExecuteCommand(locator => FindByCommand(locator, query, pageIndex, recordsPerPage));
        }
        #endregion

        #region Private Methods
        private EntityDtos<TEntityDto> FindAllCommand(IRepositoryLocator locator)
        {
            IQueryable<TEntity> all = locator.GetRepository<TEntity>().FindAll();
            var result = new EntityDtos<TEntityDto> { Entities = Mapper.Map<IQueryable<TEntity>, List<TEntityDto>>(all) };
            if (result.Entities.Count() == 0)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "No Users were found");
            return result;
        }

        private EntityDtos<TEntityDto> FindByCommand(IRepositoryLocator locator, Query query, int pageIndex, int recordsPerPage)
        {
            IQueryable<TEntity> all = locator.GetRepository<TEntity>().FindBy(query, pageIndex, recordsPerPage);
            IList<TEntityDto> allDto = new List<TEntityDto>();
            foreach (TEntity entity in all)
            {
                allDto.Add(EntityToEntityDto(entity));
            }
            var result = new EntityDtos<TEntityDto> { Entities = allDto };
            result.TotalRecords = locator.GetRepository<TEntity>().GetCount(query);
            if (result.TotalRecords == 0)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "No records were found");
            return result;
        }

        public virtual EntityDtos<TEntityDto> FindByQueryCommand(IRepositoryLocator locator, Query query)
        {
            IQueryable<TEntity> all = locator.GetRepository<TEntity>().FindBy(query);
            IList<TEntityDto> allDto = new List<TEntityDto>();
            foreach (TEntity entity in all)
            {
                allDto.Add(EntityToEntityDto(entity));
            }
            var result = new EntityDtos<TEntityDto> { Entities = allDto };
            result.TotalRecords = locator.GetRepository<TEntity>().GetCount(query);
            if (result.TotalRecords == 0)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "No records were found");
            return result;
        }
        #endregion

        #region abstract methods
        public abstract TEntityDto EntityToEntityDto(TEntity entity);
        public abstract TEntity EntityDtoToEntity(TEntityDto entityDto);
        #endregion 

        //#region Private Methods

        //private static TEntityDto EntityToEntityDto(TEntity entity)
        //{
        //    return Mapper.Map<TEntity, TEntityDto>(entity);
        //}

        //private static TEntity EntityDtoToEntity(TEntityDto entityDto)
        //{
        //    return Mapper.Map<TEntityDto, TEntity>(entityDto);
        //}
        //#endregion 
    }
}
