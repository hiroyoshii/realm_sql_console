using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmSqlStudio.RealmSql;

namespace RealmSqlStudio.Parser
{
    public class QueryContent
    {
        public string TableName { get; set; }

        public string[] Columns { get; set; }

        public WhereCondition[] WhereClause { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"TableName:{TableName}");
            sb.AppendLine($"Columns:{string.Join("|", Columns)}");
            sb.AppendLine($"Where:{string.Join("|", WhereClause.Select(x => x.ToString()))}");
            return sb.ToString();
        }

        internal bool AdaptWhereClause(SampleTable x)
        {
            foreach(var condition in WhereClause)
            {
                var value = x.GetType().GetProperty(condition.ColumnName).GetValue(x);
                if (condition.ComparedOpe == "=" && value?.ToString() != condition.Condition)
                {
                    return false;
                }
            }
            return true;
        }

        internal List<string> SelectColumns(SampleTable x)
        {
            var list = new List<string>();
            foreach(var column in Columns)
            {
                var value = x.GetType().GetProperty(column).GetValue(x);
                list.Add(value?.ToString());
            }
            return list;
        }
    }
}
