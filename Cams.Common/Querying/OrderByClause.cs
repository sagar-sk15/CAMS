using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cams.Common.Querying
{
    public class OrderByClause
    {
        public string PropertyName { get; set; }
        public bool Desc { get; set; }
    }

    [DataContract]
    public class Alias
    {
        public Alias(string aliasName,string aliasFor)
        {
            this.AliasFor = aliasFor;
            this.AliasName = aliasName;
            this.JoinType = Querying.JoinType.InnerJoin;
        }

        public Alias(string aliasName, string aliasFor, JoinType joinType)
        {
            this.AliasFor = aliasFor;
            this.AliasName = aliasName;
            this.JoinType = joinType;
        }

        [DataMember]
        public string AliasName { get; set; }
        [DataMember]
        public string AliasFor { get; set; }
        [DataMember]
        public JoinType JoinType { get; set; }
    }

    [DataContract]
    public class JoinParameters
    {
        public JoinParameters(string associationPath, string alias, JoinType joinType, IList<Criterion> withClauseCriteria)
        {
            this.AssociationPath = associationPath;
            this.Alias= alias;
            this.JoinType = joinType;
            _criteria = withClauseCriteria;
        }

        [DataMember]
        public string AssociationPath { get; set; }
        [DataMember]
        public string Alias { get; set; }
        [DataMember]
        public JoinType JoinType { get; set; }
        [DataMember]
        private IList<Criterion> _criteria = new List<Criterion>();
        [DataMember]
        public QueryOperator WithClauseOperator{ get; set; }
        public IEnumerable<Criterion> Criteria
        {
            get { return _criteria; }
        }
    }
}
