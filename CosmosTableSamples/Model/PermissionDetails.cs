using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Model
{
    public class PermissionDetails : TableEntity 
    {
        public PermissionDetails()
        {
                
        }

        public PermissionDetails(string userId, string targetId)
        {
            PartitionKey = userId;
            RowKey = targetId;
        }

        public string Access { get; set; }
    }
}
