using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealmSqlStudio.Parser;

namespace RealmSqlStudio.RealmSql
{
    public class RealmQuery
    {
        private QueryContent queryContent;

        public RealmQuery(QueryContent parsedResult, RealmFilePath realmFile)
        {
            this.queryContent = parsedResult;
        }

        internal string ExecuteQuery()
        {
            //TODO realm select by queryContent.TableName
            var table = new List<SampleTable>() { new SampleTable("a","b"), new SampleTable("a", "c"), new SampleTable("d", "c") };
            var results = table
                .Where(x => queryContent.AdaptWhereClause(x))
                .Select(x =>  queryContent.SelectColumns(x));
            var columnLengthList = queryContent.Columns.Select(x => x.Length).ToList();
            

            var header = "|" + string.Join(" ",queryContent.Columns.Select(x => string.Format("{0, -"+(x.Length+2).ToString()+"}", x)+"|")) + "\n";
            return header + string.Join("\n", results.Select(x => Format(x,columnLengthList)));
        }

        private string Format(List<string> list, List<int> columnLengthList)
        {
            var sb = new StringBuilder();
            sb.Append("|");
            for(var i=0;i< list.Count; i++)
            {
                sb.Append(string.Format("{0, -" + (columnLengthList[i] + 2) + "}", list[i]));
                sb.Append("|");
            }
            return sb.ToString();
        }
    }

    public class SampleTable
    {
        public SampleTable(string v1, string v2)
        {
            SampleColumn = v1;
            SampleColumn2 = v2;
        }
        public string SampleColumn { get; set; } = "a";
        public string SampleColumn2 { get; set; } = "b";
    }
}
