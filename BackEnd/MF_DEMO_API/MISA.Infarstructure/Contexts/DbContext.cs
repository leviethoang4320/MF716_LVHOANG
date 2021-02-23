using Dapper;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MISA.DataLayer
{
    public class DbContext<TEntity> : IDbContext<TEntity>
    {
        #region Declare

        /// <summary>
        /// chuỗi kết nối đến DB: MS2_16_LVHoang_CUKCUK
        /// </summary>
        public string connectionString = Properties.Resources.connectionString;

        protected IDbConnection _dbConnection; 

        #endregion

        #region Constructor

        public DbContext()
        {
            _dbConnection = new MySqlConnection(connectionString);
        }
        #endregion

        #region Methods

        public IEnumerable<TEntity> GetAll()
        {
            string className = typeof(TEntity).Name;
            
            var entities = _dbConnection.Query<TEntity>($"{className}_GetAll", commandType: CommandType.StoredProcedure);
            return entities;
        }

        
        public IEnumerable<TEntity> GetData(string commandText)
        {
            string className = typeof(TEntity).Name;
            var sql = commandText;
            var entities = _dbConnection.Query<TEntity>(sql);
            return entities;
        }


        
        public TEntity GetById(object id)
        {
            string className = typeof(TEntity).Name;
            var sql = $"SELECT * FROM {className} WHERE {className}Id = '{id.ToString()}'";
            return _dbConnection.Query<TEntity>(sql).FirstOrDefault();
        }
        
        public int Insert(TEntity entity)
        {
            string className = typeof(TEntity).Name;

            var effectRows = _dbConnection.Execute($"{className}_Insert", entity, commandType: CommandType.StoredProcedure);
            return effectRows;
        }

        
        public int Update(TEntity entity, Guid id)

        {
            
            string className = typeof(TEntity).Name;
            

            var effectRows = _dbConnection.Execute($"{className}_Update", entity, commandType: CommandType.StoredProcedure);
            return effectRows;
        }

        
        public int Delete(object id)
        {
            string className = typeof(TEntity).Name;
            var sql = $"DELETE FROM {className} Where {className}Id = '{id}' ";
            var effectRows = _dbConnection.Execute(sql);
            return effectRows;
        }

        #endregion

    }
}
