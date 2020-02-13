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
            var table = new List<SampleTable>() { new SampleTable()};
            return table
                .Where(x => true)// TODO where 句を実現する
                .Select(x =>  new { x.SampleColumn, x.SampleColumn2}).ToString(); // TODO select 句を実現する

        }
    }

    public class SampleTable
    {
        public string SampleColumn { get; set; } = "a";
        public string SampleColumn2 { get; set; } = "b";
    }
}
