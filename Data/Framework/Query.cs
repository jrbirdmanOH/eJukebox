using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace Data.Framework
{

    public interface IQuery
    {

    }

    public enum QueryType
    {
        StoredProc,
        Function,
        StoredProcWithValues
    }

    public class Query : IQuery
    {
        private string _query;
        private QueryType _queryType;
        private Parameter[] _parameters = null;
        private string _end;

        private const string StoredProcSQL = "EXECUTE [{0}] ";
        private const string FunctionSQL = "SELECT * FROM [dbo].[{0}]";

        private Query()
        { }

        public Query(string name, QueryType queryType, Parameter[] parameters = null, string end = "")
        {
            _query = string.Format(queryType.IsIn(QueryType.StoredProc, QueryType.StoredProcWithValues) ? StoredProcSQL : FunctionSQL, name);
            _queryType = queryType;
            _parameters = parameters;
            _end = end;
        }

        public string Sql
        {
            get
            {
                var sql = new StringBuilder(_query);
                if (_parameters.Length > 0)
                {
                    if (_queryType == QueryType.Function) sql.Append("(");
                    if (_queryType == QueryType.StoredProcWithValues)
                    {
                        sql.Append(string.Join(", ", _parameters.Select(x => SqlPreppedValue(x))));
                    }
                    else
                    {
                        sql.Append(string.Join(", ", 1.To(_parameters.Length).Select(x => $"@p{x - 1}")));
                    }
                    if (_queryType == QueryType.Function) sql.Append(")");
                }
                sql.Append(_end);

                return sql.ToString();
            }
        }

        private object SqlPreppedValue(Parameter parameter)
        {
            if (parameter.Type == typeof(int))
            {
                return $"{((Parameter<int>)parameter).Value}";
            }
            else if (parameter.Type == typeof(int?))
            {
                if (((Parameter<int?>) parameter).Value != null)
                {
                    return $"{((Parameter<int?>)parameter).Value}";
                }
            }
            else if (parameter.Type == typeof(Date))
            {
                return $"'{((Parameter<Date>)parameter).Value}'";
            }
            else if (parameter.Type == typeof(DateTime))
            {
                return $"'{((Parameter<DateTime>)parameter).Value}'";
            }
            else if (parameter.Type == typeof(string))
            {
                if (((Parameter<string>) parameter).Value != null)
                {
                    return $"'{((Parameter<string>) parameter).Value}'";
                }
            }
            else if (parameter.Type == typeof(bool))
            {
                return $"{((Parameter<bool>)parameter).Value}";
            }
            else if (parameter.Type == typeof(Decimal))
            {
                return $"{((Parameter<Decimal>)parameter).Value}";
            }

            return "null";
        }

        public object[] Parameters
        {
get
            {
                if (_queryType != QueryType.StoredProcWithValues)
                {
                    int j = 0;
                    return _parameters.Select(x =>
                        new SqlParameter() {ParameterName = $"p{j++}", Value = GetParameterValue(x)}).ToArray();
                }
                else
                {
                    return null;
                }
            }
        }

        private object GetParameterValue(Parameter parameter)
        {
            if (parameter.Type.Equals(typeof(int)))
            {
                return ((Parameter<int>)parameter).Value;
            }
            else if (parameter.Type.Equals(typeof(int?)))
            {
                if (((Parameter<int?>) parameter).Value != null)
                {
                    return ((Parameter<int?>) parameter).Value;
                }
            }
            else if (parameter.Type.Equals(typeof(Date)))
            {
                return ((Parameter<Date>)parameter).Value;
            }
            else if (parameter.Type.Equals(typeof(DateTime)))
            {
                return ((Parameter<DateTime>)parameter).Value;
            }
            else if (parameter.Type.Equals(typeof(string)))
            {
                if (((Parameter<string>) parameter).Value != null)
                {
                    return ((Parameter<string>) parameter).Value;
                }
            }
            else if (parameter.Type.Equals(typeof(bool)))
            {
                return ((Parameter<bool>)parameter).Value;
            }
            else if (parameter.Type.Equals(typeof(Decimal)))
            {
                return ((Parameter<Decimal>)parameter).Value;
            }

            return DBNull.Value;
        }
    }
}

