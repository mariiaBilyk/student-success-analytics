using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Generic {
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class {
        protected virtual string ConnectionString 
            => ConfigurationManager.ConnectionStrings["StudentSuccessConString"].ConnectionString;

        public virtual string TableName => string.Empty;

        public TEntity GetById ( string tableName, string idName, int id ) {
            using ( var connection = OpenConnection() ) {
                var sql = $@"SELECT * 
                             FROM {tableName} 
                             WHERE {idName} = {id}";

                var entry = connection.Query<TEntity>(sql);
                return entry.FirstOrDefault();
            }
        }

        public virtual IEnumerable<TEntity> GetAll ( string tableName ) {
            using ( var connection = OpenConnection() ) {
                var sql = $@"SELECT * FROM {tableName}";
                var entries = connection.Query<TEntity>(sql);
                return entries;
            }
        }

        public string GradeViewName => "[dbo].[Success]";
        public string StudentsViewName => string.Empty;
        public string InstituteTableName => "[dbo].[Institute]";
        public string DepartmentTableName => "[dbo].[Department]";
        public string TeacherTableName => "[dbo].[Teacher]";
        public string SubjectTableName => "[dbo].[Subject]";

        protected SqlConnection OpenConnection () {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}