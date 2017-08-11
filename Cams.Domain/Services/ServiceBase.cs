using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.TransManager;
using Cams.Domain.Repository;
using Cams.Common.Message;
using Cams.Domain.AppServices;
using AutoMapper;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto;
using Cams.Common.Logging;
using Cams.Domain.Entities;
using System.Collections.ObjectModel;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Domain.Services
{
    public abstract class ServiceBase<TEntity, TEntityDto>
    {
        public bool AllowSaveWithWarnings { get; protected set; }
        public bool IsValidForBasicMandatoryFields { get; protected set; }
        public bool IsValid { get; protected set; }
        public bool PopulateChildObjects { get; set; }

        protected TResult ExecuteCommand<TResult>(Func<IRepositoryLocator, TResult> command)
        //where TResult : class, IDtoResponseEnvelop
        {
            using (ITransManager manager = Container.GlobalContext.TransFactory.CreateManager())
            {
                return manager.ExecuteCommand(command);
            }
        }

        #region abstract methods

        protected abstract void CheckForValidations(TEntity entity);
        protected abstract void CheckForValidationsWhileUpdating(TEntity entity);
        public abstract TEntityDto EntityToEntityDto(TEntity entity);
        public abstract TEntity EntityDtoToEntity(TEntityDto entityDto);
        protected abstract string GetEntityInstanceName(TEntity entity);

        #endregion

        #region CRUD methods

        public TEntityDto GetById(long id)
        {
            LoggingFactory.LogInfo("Invoked GetById for " + typeof(TEntity).Name + " : Id : " + id);
            var result = ExecuteCommand(loc => EntityToEntityDto(loc.GetById<TEntity>(id)));
            if (result == null)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, typeof(TEntity).Name + " with id: " + id + " not found");
            return result;
        }

        public TEntityDto GetById(int id)
        {
            LoggingFactory.LogInfo("Invoked GetById for " + typeof(TEntity).Name + " : Id : " + id);
            var result = ExecuteCommand(loc => EntityToEntityDto(loc.GetById<TEntity>(id)));
            if (result == null)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, typeof(TEntity).Name + " with id:" + id + " not found");
            return result;
        }

        public TEntityDto Update(TEntityDto entityDto, string userName)
        {
            LoggingFactory.LogInfo("Invoked Update for " + typeof(TEntity).Name);
            return ExecuteCommand(locator => UpdateCommand(locator, entityDto, userName));
        }

        public TEntityDto Create(TEntityDto entityDto, string userName)
        {
            LoggingFactory.LogInfo("Invoked Create for " + typeof(TEntity).Name);
            return ExecuteCommand(locator => CreateNewCommand(locator, entityDto, userName));
        }


        public DtoResponse Delete(long id)
        {
            LoggingFactory.LogInfo("Invoked Delete for " + typeof(TEntity).Name + " : Id : " + id);
            return ExecuteCommand(locator => DeleteCommand(locator, id));
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

        public virtual TEntityDto CreateNewCommand(IRepositoryLocator locator, TEntityDto entityDto, string userName)
        {
            PopulateChildObjects = true;
            TEntity entity = EntityDtoToEntity(entityDto);

            //checks for the valid object and adds warnings/validation rules to Request object
            CheckForValidations(entity);

            TEntityDto result;
            if ((AllowSaveWithWarnings && IsValidForBasicMandatoryFields) || IsValid)
            {
                PopulateChildObjects = false;
                locator.GetRepository<TEntity>().Add(entity);
                LoggingFactory.LogInfo("Created " + typeof(TEntity).Name + " : Id : ");

                string description = "Created " + typeof(TEntity).Name + " : " + GetEntityInstanceName(entity);
                LoggActivity(description, userName);
            }
            else
            {
                string description = "Failed to create " + typeof(TEntity).Name + " : " + GetEntityInstanceName(entity);
                LoggingFactory.LogInfo(description);
                //LoggActivity(description, loggedInUserDto);
            }
            //if (populateChildObjects != null)
            //    PopulateChildObjects = Convert.ToBoolean(populateChildObjects);
            PopulateChildObjects = false;
            result = EntityToEntityDto(entity);
            return result;
        }

        public virtual TEntityDto UpdateCommand(IRepositoryLocator locator, TEntityDto entityDto, string userName)
        {
            string description = string.Empty;
            PopulateChildObjects = true;
            TEntity entityInstance = EntityDtoToEntity(entityDto);
            if (userName != null)
            {
                CheckForValidationsWhileUpdating(entityInstance);
                if ((AllowSaveWithWarnings && IsValidForBasicMandatoryFields) || IsValid)
                {
                    locator.GetRepository<TEntity>().Update(entityInstance);
                    description = "Updated " + typeof(TEntity).Name + " : " + GetEntityInstanceName(entityInstance);
                    LoggActivity(description, userName);
                }
                else
                {
                    description = "Failed to create " + typeof(TEntity).Name + " : " + GetEntityInstanceName(entityInstance);
                    LoggingFactory.LogInfo(description);
                }
            }
            else
            {
                locator.GetRepository<TEntity>().Update(entityInstance);
                description = "Failed to Login " + typeof(TEntity).Name + " : " + GetEntityInstanceName(entityInstance);
                LoggingFactory.LogInfo(description);
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, "Invalid Username or Password");
            }
            //if(populateChildObjects!=null)
            //PopulateChildObjects = Convert.ToBoolean(populateChildObjects);
            PopulateChildObjects = false;
            return EntityToEntityDto(entityInstance);
        }

        private DtoResponse DeleteCommand(IRepositoryLocator locator, long id)
        {
            var TEntity = locator.GetById<TEntity>(id);
            //BusinessNotifier.AddWarning (BusinessWarningEnum.Default,
            //                            string.Format ("TEntity with id:{0} was deleted",
            //                            TEntity.Id));
            //string description = "Deleted " + typeof(TEntity).Name + " : " + GetEntityInstanceName(TEntity);                        
            //LoggActivity(description, loggedInUserDto);
            locator.Remove(TEntity);
            return new DtoResponse();
        }

        private EntityDtos<TEntityDto> FindAllCommand(IRepositoryLocator locator)
        {
            IQueryable<TEntity> all = locator.GetRepository<TEntity>().FindAll();
            IList<TEntityDto> allDto = new List<TEntityDto>();
            PopulateChildObjects = false;
            foreach (TEntity entity in all)
            {
                allDto.Add(EntityToEntityDto(entity));
            }
            var result = new EntityDtos<TEntityDto> { Entities = allDto };
            result.TotalRecords = result.Entities.Count();
            if (result.TotalRecords == 0)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "No Records were found");
            return result;
        }

        /// <summary>
        /// LoggActivity method log the information of the user in ActivityLogDto and pass it to create method of ActivityLogService.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="loggedInUserDto"></param>
        private void LoggActivity(string description, string userName)
        {
            ActivityLogService activityLogService;
            Cams.Common.Dto.Log.ActivityLogDto activityLogDto;

            activityLogDto = new Cams.Common.Dto.Log.ActivityLogDto();
            activityLogDto.LoggedBy = userName;
            activityLogDto.LoggedDate = DateTime.Now;
            activityLogDto.Description = description;
            activityLogDto.ActivityRelatedTo = typeof(TEntity).Name;

            activityLogService = new ActivityLogService();
            activityLogService.Create(activityLogDto, userName);
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
    }
}
