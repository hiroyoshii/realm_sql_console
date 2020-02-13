using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSqlStudio.Parser
{
    public class SqlParser
    {
        private const string SELECT = "select";
        private const string FROM = "from";
        private const string WHERE = "where";
        private string sqlString;

        public SqlParser(string input)
        {
            this.sqlString = input;
        }

        internal QueryContent Parse()
        {
            return new QueryContent()
            {
                Columns = ParseColumns(),
                TableName = ParseTableName(),
                WhereClause = ParseWhereClause(),
            };
        }

        private WhereCondition[] ParseWhereClause()
        {
            int pFrom = sqlString.IndexOf(WHERE) + WHERE.Length;
            int pTo = sqlString.Length;
            return new WhereClauseParser(sqlString.Substring(pFrom, pTo - pFrom).Trim()).Parse();
        }

        private string ParseTableName()
        {
            int pFrom = sqlString.IndexOf(FROM) + FROM.Length;
            int pTo = sqlString.IndexOf(WHERE);
            if (pTo == -1)
            {
                pTo = sqlString.Length;
            }
            return sqlString.Substring(pFrom, pTo - pFrom).Trim();
        }

        private string[] ParseColumns()
        {
            int pFrom = sqlString.IndexOf(SELECT) + SELECT.Length;
            int pTo = sqlString.IndexOf(FROM);
            var columns = sqlString.Substring(pFrom, pTo - pFrom).Split(',');
            return columns.Select(x => x.Trim()).ToArray();
        }
    }
}
