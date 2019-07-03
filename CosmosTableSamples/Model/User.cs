using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Model
{
   public class User : TableEntity
    {
        public User()
        {
        }

        public User(string userName, string source)
        {
            PartitionKey = userName;
            RowKey = source;
        }

        public string Value { get; set; }

        
    }
}
