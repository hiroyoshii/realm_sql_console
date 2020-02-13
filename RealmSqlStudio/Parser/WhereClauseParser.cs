using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSqlStudio.Parser
{
    class WhereClauseParser
    {
        private const string EQUALITY = "=";
        private string whereClause;

        public WhereClauseParser(string whereClause)
        {
            this.whereClause = whereClause;
        }

        internal WhereCondition[] Parse()
        {
            var splitted = whereClause.Split(new string[] { "and" }, StringSplitOptions.None);
            return splitted.Select(x => CreateCondition(x)).ToArray();
        }

        private WhereCondition CreateCondition(string clause)
        {
            if (clause.Contains(EQUALITY))
            {
                var equalCondition = clause.Split(new string[] { EQUALITY }, StringSplitOptions.None).Select(x => x.Trim()).ToArray();
                if (equalCondition.Length == 2)
                {
                    return new WhereCondition(equalCondition[0], equalCondition[1], EQUALITY);
                }
            }
            throw new Exception($"unsuported where clause condition : {clause}");
        }
    }
}
