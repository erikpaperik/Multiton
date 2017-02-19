using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multiton;

namespace MultitonTest
{
    [TestClass]
    public class MultitonTest
    {
        [TestMethod]
        public void DbPoolConnection_GetInstance_WithNotExistingKey_ReturnsNewDbPoolConnection()
        {
            DbPoolConnection poolConnection;

            poolConnection = DbPoolConnection.getInstance(0);

            Assert.IsNotNull(poolConnection.getDatabaseConnection(), "DbConnection should not be null");
        }

        [TestMethod]
        public void DbPoolConnectionl_GetInstance_ReturnsSameInstanceForSameKey()
        {
            DbPoolConnection poolConnectionOne, poolConnectionTwo;

            poolConnectionOne = DbPoolConnection.getInstance(0);
            poolConnectionTwo = DbPoolConnection.getInstance(0);

            Assert.AreSame(poolConnectionOne, poolConnectionTwo, "DbPoolConnection objects should be the same");
        }

        [TestMethod]
        public void DbPoolConnection_GetDbConnection_ReturnsADbConnectionObject()
        {
            DbPoolConnection poolConnection = DbPoolConnection.getInstance(0);

            DbConnection connection = poolConnection.getDatabaseConnection();

            Assert.IsTrue(connection.GetType() == typeof(DbConnection), "Types doesn't match");
        }

        [TestMethod]
        public void DbPoolConnection_DbConnection_HasDefaultConnectionString()
        {
            DbPoolConnection connection = DbPoolConnection.getInstance(0);

            String defaultConnectionString = connection.getDatabaseConnection().getConnectionString();

            Assert.AreEqual(DbPoolConnection.defaultConnectionString, defaultConnectionString, "DefaultConnectionString not correct");
        }
    }
}
