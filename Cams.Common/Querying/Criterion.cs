using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Runtime.Serialization;

namespace Cams.Common.Querying
{
    [DataContract]
    [KnownType(typeof(Common.UnitType))]
    //[KnownType(typeof(JoinType))]
    public class Criterion
    {
        private string _propertyName;
        private object _value;
        private object[] _values;
        private CriteriaOperator _criteriaOperator;
        
        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            _propertyName = propertyName;
            _value = value;
            _criteriaOperator = criteriaOperator;
        }

        //public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator, JoinType joinType)
        //{
        //    _propertyName = propertyName;
        //    _value = value;
        //    _criteriaOperator = criteriaOperator;
        //    //JoinType = joinType;
        //}

        [DataMember]
        public string PropertyName 
        {
            get { return _propertyName; }
            private set { _propertyName = value; }
        }

        [DataMember]
        public object Value
        {
            get { return _value; }
            private set { _value = value; }
        }
        [DataMember]
        public object[] Values
        {
            get { return _values; }
            private set { _values = value; }
        }

        [DataMember]
        public CriteriaOperator criteriaOperator
        {
            get { return _criteriaOperator; }
            private set { _criteriaOperator = value; }
        }

        //[DataMember]
        //public JoinType JoinType { get; set; }

        public static Criterion Create<T>(Expression<Func<T, object>> expression, object value, CriteriaOperator criteriaOperator)
        {
            string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator);
            return myCriterion;
        }
           
     
    }
}
