using System;

namespace Multiton
{
    public class DbConnection
    {
        private string connectionString;

        private void setConnectionString(string value)
        {
            if (value == String.Empty)
                throw new ArgumentNullException("value");
            this.connectionString = value;
        }

        public string getConnectionString()
        {
            return this.connectionString;
        }

        public DbConnection(string connectionString)
        {
            setConnectionString(connectionString);
        }

        public void Open()
        {
            Console.WriteLine("Connection open");
        }

    }
}