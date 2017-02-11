using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsep.Models;

namespace Tsep
{
    public class StorageContext
    {
        CloudTableClient tableclient;
        CloudTable _table;
        public StorageContext( CloudStorageAccount account,string tablename)
        {
            tableclient = account.CreateCloudTableClient();
            _table = tableclient.GetTableReference(tablename);
            
        }
        //public IEnumerable<CollegeEntity> GetAll()
        //{
        //    _table.ExecuteQuery()
        //    query = new TableQuery<Colleges>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Colleges"));
        //    foreach (CollegeEntity item in _table.ExecuteQuerySegmentedAsync())
        //    {

        //    }
        //}

    }
}
