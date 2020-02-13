using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
