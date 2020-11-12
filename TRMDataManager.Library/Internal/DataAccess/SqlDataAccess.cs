using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess : IDisposable
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public string GetConnectionString(string connectionString)
        {
            return _config.GetConnectionString(connectionString);
            // old way - return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        public List<T> LoadData<T,U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                List<T> rows = conn.Query<T>(storedProcedure, parameters, 
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        //Open connection/start transaction method
        //load using transaction
        //save using transaction
        //close connection/stop transaction method
        //Dispose

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();

            isClosed = false;
        }
        public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
                List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

                return rows;
        }

        public void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            _connection.Execute(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction:_transaction);
        }

        private bool isClosed = false;

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
            isClosed = true;
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
            isClosed = true;
        }

        public void Dispose()
        {
            if (isClosed == false)
            {
                try
                {
                    CommitTransaction();
                }
                catch 
                {
                    //TODO:: Log this issue
                }
            }

            _transaction = null;
            _connection = null;
        }
    }
}
