using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Cams.Common.Querying;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

using JoinType = Cams.Common.Querying.JoinType;

namespace Cams.Dal.Repository
{
    public static class QueryTranslator
    {
        public static ICriteria TranslateIntoNHQuery<T>(this Query query, ICriteria criteria)
        {
            
            BuildQueryFrom(query, criteria);

            if (query.JoinParameters != null)
            {
                foreach (Cams.Common.Querying.JoinParameters joinParameters in query.JoinParameters)
                {
                    BuildJoinCriteria(joinParameters.AssociationPath, joinParameters.Alias,
                        (NHibernate.SqlCommand.JoinType)joinParameters.JoinType, joinParameters.Criteria, joinParameters.WithClauseOperator, criteria);
                }
            }
            if (query.Alias != null)
            {
                foreach (Cams.Common.Querying.Alias alias in query.Alias)
                {
                    criteria.CreateAlias(alias.AliasFor, alias.AliasName, (NHibernate.SqlCommand.JoinType)alias.JoinType);
                }
            }

            if (query.OrderByFields!= null)
            {
                foreach (Cams.Common.Querying.OrderByClause orderBy in query.OrderByFields)
                {
                    criteria.AddOrder(new Order(orderBy.PropertyName, !orderBy.Desc));
                }
            }
            return criteria;            
        }

        private static void BuildJoinCriteria(string AssociationPath, string Alias, global::NHibernate.SqlCommand.JoinType joinType,
            IEnumerable<Cams.Common.Querying.Criterion> JoinConditions, QueryOperator JoiningConditionsOperator, ICriteria criteria)
        {
            criteria.CreateCriteria(associationPath: AssociationPath, alias: Alias, joinType: joinType);

            IList<ICriterion> criterions = new List<ICriterion>();

            if (JoinConditions != null)
            {
                global::NHibernate.Criterion.ICriterion criterion;

                foreach (Criterion c in JoinConditions)
                {
                    switch (c.criteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            criterion = Expression.Eq(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThanOrEqual:
                            criterion = Expression.Le(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.GreaterThanOrEqual:
                            criterion = Expression.Ge(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThan:
                            criterion = Expression.Lt(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.GreaterThan:
                            criterion = Expression.Gt(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.NotEqual:
                            criterion = Expression.Not(Expression.Eq(c.PropertyName, c.Value));
                            break;
                        case CriteriaOperator.IsNullOrZero:
                            criterion = Expression.Or(Expression.IsNull(c.PropertyName), Expression.Eq(c.PropertyName, 0));
                            break;
                        case CriteriaOperator.IsNotNullOrZero:
                            criterion = Expression.Not(Expression.Or(Expression.IsNull(c.PropertyName), Expression.Eq(c.PropertyName, 0)));
                            break;
                        case CriteriaOperator.In:
                            criterion = Expression.In(c.PropertyName, c.Values);
                            break;
                        case CriteriaOperator.NotIn:
                            criterion = Expression.Not(Expression.In(c.PropertyName, c.Values));
                            break;
                        case CriteriaOperator.Like:
                            criterion = Expression.Like(c.PropertyName, c.Value.ToString(), MatchMode.Start);
                            break;
                        case CriteriaOperator.NotLike:
                            criterion = Expression.Not(Expression.Like(c.PropertyName, c.Value.ToString(), MatchMode.Start));
                            break;
                        default:
                            throw new ApplicationException("No operator defined");
                    }
                    criterions.Add(criterion);
                }

                if (JoiningConditionsOperator == QueryOperator.And)
                {
                    Conjunction andSubQuery = Expression.Conjunction();
                    foreach (ICriterion cri in criterions)
                    {
                        andSubQuery.Add(cri);
                    }
                    criteria.Add(andSubQuery);
                }
                else
                {
                    Disjunction orSubQuery = Expression.Disjunction();
                    foreach (ICriterion cri in criterions)
                    {
                        orSubQuery.Add(cri);
                    }
                    criteria.Add(orSubQuery);
                }
            }
        }

        private static void BuildQueryFrom(Query query, ICriteria criteria)
        {
            IList<ICriterion> criterions = new List<ICriterion>();
            
            if (query.Criteria != null)
            {
                foreach (Criterion c in query.Criteria)
                {
                    global::NHibernate.Criterion.ICriterion criterion ;
                    
                    switch (c.criteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            criterion = Expression.Eq(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThanOrEqual:
                            criterion = Expression.Le(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.GreaterThanOrEqual:
                            criterion = Expression.Ge(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThan:
                            criterion = Expression.Lt(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.GreaterThan:
                            criterion = Expression.Gt(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.NotEqual:
                            criterion = Expression.Not(Expression.Eq(c.PropertyName, c.Value));
                            break;
                        case CriteriaOperator.IsNullOrZero:
                            criterion = Expression.Or(Expression.IsNull(c.PropertyName), Expression.Eq(c.PropertyName, 0));
                            break;
                        case CriteriaOperator.IsNotNullOrZero:
                            criterion =  Expression.Not(Expression.Or(Expression.IsNull(c.PropertyName), Expression.Eq(c.PropertyName, 0)));
                            break;
                        case CriteriaOperator.In:
                            criterion = Expression.In(c.PropertyName, c.Values);
                            break;
                        case CriteriaOperator.NotIn:
                            criterion = Expression.Not(Expression.In(c.PropertyName, c.Values));
                            break;
                        case CriteriaOperator.Like:
                            criterion = Expression.Like(c.PropertyName, c.Value.ToString(), MatchMode.Start);
                            break;
                        case CriteriaOperator.NotLike:
                            criterion = Expression.Not(Expression.Like(c.PropertyName, c.Value.ToString(), MatchMode.Start));
                            break;

                        default:
                            throw new ApplicationException("No operator defined");
                    }
                    

                    criterions.Add(criterion);
                }

                if (query.QueryOperator == QueryOperator.And)
                {
                    Conjunction andSubQuery = Expression.Conjunction();
                    foreach (ICriterion criterion in criterions)
                    {
                        andSubQuery.Add(criterion);
                    }

                    criteria.Add(andSubQuery);
                }
                else
                {
                    Disjunction orSubQuery = Expression.Disjunction();
                    foreach (ICriterion criterion in criterions)
                    {
                        orSubQuery.Add(criterion);
                    }
                    criteria.Add(orSubQuery);
                }

                foreach (Query sub in query.SubQueries)
                {
                    BuildQueryFrom(sub, criteria);
                }
                
            }
        }
    }
}
