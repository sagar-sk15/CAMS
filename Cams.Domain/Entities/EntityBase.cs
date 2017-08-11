using System;
using System.Collections.Generic;
using System.Text;


namespace Cams.Domain.Entities
{
    public abstract class EntityBase<TId> : IEntity<TId>
    {
        #region proterties
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();
        //protected virtual TId Id { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual bool IsValidForBasicMandatoryFields { get; set; }
        
        #endregion

        #region abstract methods
        public abstract void Validate();
        #endregion

        #region methods
        public virtual IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            IsValid = true;
            IsValidForBasicMandatoryFields = true;
            Validate();
            if (_brokenRules.Count > 0)
                IsValid = false;

            return _brokenRules;                       
        }


        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        



        //public override bool Equals(object entity)
        //{
        //    return entity != null
        //       && entity is EntityBase<TId>
        //       && this == (EntityBase<TId>) entity;

        //}

        //public override int GetHashCode()
        //{          
        //    return this.Id.GetHashCode();         
        //}

        //public static bool operator == (EntityBase<TId> entity1, EntityBase<TId> entity2)
        //{
        //    if ((object)entity1 == null && (object)entity2 == null)
        //    {
        //        return true;
        //    }

        //    if ((object)entity1 == null || (object)entity2 == null)
        //    {
        //        return false;
        //    }

        //    if (entity1.Id.ToString() == entity2.Id.ToString())
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public static bool operator != (EntityBase<TId> entity1, EntityBase<TId> entity2)
        //{
        //    return (!(entity1 == entity2));
        //}
                
        #endregion

    }
}
