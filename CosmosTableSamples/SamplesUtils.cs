using System;
using System.Linq;

namespace CosmosTableSamples
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Model;

    class SamplesUtils
    {
        public static async Task<CustomerEntity> RetrieveEntityUsingPointQueryAsync(CloudTable table, string partitionKey, string rowKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<CustomerEntity>(partitionKey, rowKey);
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                CustomerEntity customer = result.Result as CustomerEntity;
                if (customer != null)
                {
                    // var cardetails = customer.Car;
                    //var items =cc.IndexAsync(cardetails);

                    //var year = items.Select(x => x.Model == cardetails);

                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", customer.PartitionKey, customer.RowKey, customer.Email, customer.PhoneNumber, customer.Car);
                }

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of Retrieve Operation: " + result.RequestCharge);
                }

                return customer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public static async Task<PermissionDetails> RetrievePermissionUsingPointQueryAsync(CloudTable table, string partitionKey, string rowKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<PermissionDetails>(partitionKey, rowKey);
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                PermissionDetails perDetails = result.Result as PermissionDetails;
                if (perDetails != null)
                {
                  

                    Console.WriteLine("\t{0}\t{1}\t{2}",perDetails.Access,perDetails.RowKey,perDetails.PartitionKey);
                }

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of Retrieve Operation: " + result.RequestCharge);
                }

                return perDetails;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public static async Task<User> RetrieveUserUsingPointQueryAsync(CloudTable table, string partitionKey, string rowKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<User>(partitionKey, rowKey);
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                User perDetails = result.Result as User;
                if (perDetails != null)
                {


                    Console.WriteLine("\t{0}\t{1}\t{2}", perDetails.Value, perDetails.RowKey, perDetails.PartitionKey);
                }

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of Retrieve Operation: " + result.RequestCharge);
                }

                return perDetails;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public static async Task<CustomerEntity> InsertOrMergeEntityAsync(CloudTable table, CustomerEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                CustomerEntity insertedCustomer = result.Result as CustomerEntity;

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }

                return insertedCustomer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }


        public static async Task<PermissionDetails> InsertOrMergePermissionAsync(CloudTable table, PermissionDetails entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                PermissionDetails insertedCustomer = result.Result as PermissionDetails;

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }

                return insertedCustomer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public static async Task<User> InsertOrMergeUserAsync(CloudTable table, User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                User insertedCustomer = result.Result as User;

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }

                return insertedCustomer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
        public static async Task DeleteEntityAsync(CloudTable table, CustomerEntity deleteEntity)
        {
            try
            {
                if (deleteEntity == null)
                {
                    throw new ArgumentNullException("deleteEntity");
                }

                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
                TableResult result = await table.ExecuteAsync(deleteOperation);

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of Delete Operation: " + result.RequestCharge);
                }

            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        /// <summary>
        /// Check if given connection string is for Azure Table storage or Azure CosmosDB Table.
        /// </summary>
        /// <returns>true if azure cosmosdb table</returns>
        public static bool IsAzureCosmosdbTable()
        {
            string storageConnectionString = AppSettings.LoadAppSettings().StorageConnectionString;
            return !String.IsNullOrEmpty(storageConnectionString) && (storageConnectionString.Contains("table.cosmosdb") || storageConnectionString.Contains("table.cosmos"));
        }
    }
}
