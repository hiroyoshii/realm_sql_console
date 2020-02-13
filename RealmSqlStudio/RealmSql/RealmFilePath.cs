using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmSqlStudio.RealmSql
{
    public class RealmFilePath
    {
        public string ResourcePath { get; set; }
        public string CarCode { get; set; }

        internal void Reload()
        {
            throw new NotImplementedException();
        }
    }
}
