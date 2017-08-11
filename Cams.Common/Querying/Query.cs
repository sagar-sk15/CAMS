using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cams.Common.Querying
{
    [DataContract]
    [KnownType(typeof(Common.UnitType))]
    public class Query
    {        
        
        [DataMember]
        private IList<Criterion> _criteria = new List<Criterion>(); 
        public IEnumerable<Criterion> Criteria
        {
            get {return _criteria ;}
        }

        [DataMember]
        private IList<Alias> _alias = new List<Alias>();
        public IEnumerable<Alias> Alias
        {
            get { return _alias; }
        }

        [DataMember]
        private IList<JoinParameters> _joinParameters = new List<JoinParameters>();
        public IEnumerable<JoinParameters> JoinParameters
        {
            get { return _joinParameters; }
        }

        [DataMember]
        private IList<Query> _subQueries = new List<Query>();
        public IEnumerable<Query> SubQueries
        {
            get { return _subQueries;}
        }

        [DataMember]
        private IList<OrderByClause> _orderByFields = new List<OrderByClause>();
        public IEnumerable<OrderByClause> OrderByFields
        {
            get { return _orderByFields; }
        }

        
        public void AddSubQuery(Query subQuery)
        {
            _subQueries.Add(subQuery);
        }

        public void Add(Criterion criterion)
        {           
           _criteria.Add(criterion);           
        }

        public void AddAlias(Alias alias)
        {
            _alias.Add(alias);
        }

        public void AddJoinParamteres(JoinParameters joinParamters)
        {
            _joinParameters.Add(joinParamters);
        }

        public void AddOrderByField(OrderByClause orderBy)
        {
            _orderByFields.Add(orderBy);
        }

        [DataMember]
        public QueryOperator QueryOperator { get; set; }

        [DataMember]
        public int CAId { get; set; } 

        //[DataMember]
        //public OrderByClause OrderByProperty { get; set; }

        //[DataMember]
        //public OrderByClause OrderByProperty1 { get; set; }

        //[DataMember]
        //public Alias Alias { get; set; }

        //[DataMember]
        //public Alias Alias1 { get; set; }

        //[DataMember]
        //public Alias Alias2 { get; set; }
    }
}
