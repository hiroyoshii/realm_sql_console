using RealmSqlStudio.Parser;
using RealmSqlStudio.RealmSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSqlStudio.Prompt
{
    internal class InputSql
    {
        private readonly string input;
        private readonly RealmFilePath realmFile;
        public InputSql(string input, RealmFilePath realmFile)
        {
            this.input = input;
            this.realmFile = realmFile;
        }

        public string Analyze()
        {
            var parsedResult = new SqlParser(input).Parse();
            var realmResult = new RealmQuery(parsedResult, realmFile).ExecuteQuery(); 
            var result = parsedResult.ToString();
            return realmResult;
        }
    }
}
