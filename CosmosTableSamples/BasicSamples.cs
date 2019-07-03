using System;

namespace CosmosTableSamples
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Model;

    class BasicSamples
    {
        public async Task RunSamples()
        {
            Console.WriteLine("Azure Cosmos DB Table - Basic Samples\n");
            Console.WriteLine();

            string tableName = "UserDetails";

            // Create or reference an existing table
            CloudTable table = await Common.CreateTableAsync(tableName);
            var permissionTableName = "PermissionDetails";
            CloudTable permissionTable = await Common.CreateTableAsync(permissionTableName);
            try
            {
                // Demonstrate basic CRUD functionality 
                //await BasicDataOperationsAsync(table);
                //await CarDataOpertaions(permissionTable);
                await UserDataOpertaions(permissionTable);
            }
            finally
            {
                // Delete the table
                //await table.DeleteIfExistsAsync();
            }
        }

        private static async Task BasicDataOperationsAsync(CloudTable table)
        {
            // Create an instance of a customer entity. See the Model\CustomerEntity.cs for a description of the entity.
            CustomerEntity customer = new CustomerEntity("Harp", "Walter")
            {
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101",
                Car ="Merc"
            };

            // Demonstrate how to insert the entity
            Console.WriteLine("Insert an Entity.");
            customer = await SamplesUtils.InsertOrMergeEntityAsync(table, customer);

            // Demonstrate how to Update the entity by changing the phone number
            //Console.WriteLine("Update an existing Entity using the InsertOrMerge Upsert Operation.");
            //customer.PhoneNumber = "425-555-0105";
            //await SamplesUtils.InsertOrMergeEntityAsync(table, customer);
            //Console.WriteLine();

            // Demonstrate how to Read the updated entity using a point query 
            Console.WriteLine("Reading the Entity.");
            customer = await SamplesUtils.RetrieveEntityUsingPointQueryAsync(table, "Harp", "Walter");
            Console.WriteLine();

            // Demonstrate how to Delete an entity
            //Console.WriteLine("Delete the entity. ");
            //await SamplesUtils.DeleteEntityAsync(table, customer);
            //Console.WriteLine();
        }

        private static async Task CarDataOpertaions(CloudTable table)
        {
            
            PermissionDetails permissionDetails = new PermissionDetails("Harp", "Avinava")
            {
                Access = "Granted"
            };

            // Demonstrate how to insert the entity
            Console.WriteLine("Insert an Entity.");
            permissionDetails = await SamplesUtils.InsertOrMergePermissionAsync(table, permissionDetails);

            Console.WriteLine("Reading the Entity.");
            permissionDetails = await SamplesUtils.RetrievePermissionUsingPointQueryAsync(table, "Harp", "Avinava");
            Console.WriteLine();
        }

        private static async Task UserDataOpertaions(CloudTable table)
        {

            User permissionDetails = new User("Avinava", "Internal")
            {
                Value = "Granted"
            };
            User userDetails = new User("Avinava", "External")
            {
                Value = "Avinava Basu"
            };
            // Demonstrate how to insert the entity
            Console.WriteLine("Insert an Entity.");
            permissionDetails = await SamplesUtils.InsertOrMergeUserAsync(table, permissionDetails);
            userDetails = await SamplesUtils.InsertOrMergeUserAsync(table, userDetails);

            Console.WriteLine("Reading the Entity.");
            permissionDetails = await SamplesUtils.RetrieveUserUsingPointQueryAsync(table, "Avinava", "External");
            Console.WriteLine();
        }
    }
}
