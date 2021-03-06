using System;
using System.Configuration;
using MongoDB.Driver;
using NUnit.Framework;
using Sitecore.Configuration;
using Sitecore.Data;

namespace SitecoreData.DataProviders.MongoDB.Tests
{
    internal abstract class MongoTestsBase
    {
        protected MongoDatabase _db;
        protected Database _sourceDatabase;
        protected Database _targetDatabase;

        [SetUp]
        public void CopyDataFromTemplatesFolder()
        {
            Sitecore.Context.IsUnitTesting = true;
            InitializeMongoConnection();
            _sourceDatabase = Factory.GetDatabase("master");
            _targetDatabase = Factory.GetDatabase("nosqlmongotest");
            //TransferUtil.TransferPath("/sitecore/layout", _sourceDatabase, _targetDatabase,null);
        }

        private void InitializeMongoConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["nosqlmongotest"].ConnectionString;
            var server = MongoServer.Create(connectionString);
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            _db = server.GetDatabase(databaseName);
        }


    }
}