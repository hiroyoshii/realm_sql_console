using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSqlStudio.Parser
{
    public class WhereCondition
    {
        public string ColumnName { get; private set; }
        public string Condition { get; private set; }
        public string ComparedOpe { get; private set; }

        public WhereCondition(string columnName, string condition, string comparedOpe)
        {
            this.ColumnName = columnName;
            this.Condition = condition;
            this.ComparedOpe = comparedOpe;
        }

        public override string ToString()
        {
            return $"ColumnName:{ColumnName}, ComparedOpe:{ComparedOpe}, Condition:{Condition}";
        }

    }
}
