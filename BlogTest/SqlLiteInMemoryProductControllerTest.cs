
using System;
using System.Data.Common;
using BlogTest;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Oblig2_Blogg.Data;

namespace BlogTest
{
    #region SqliteInMemory
    public class SqlLiteInMemoryProductControllerTest : RepositoryTest, IDisposable
    {
        private readonly DbConnection _connection;

        public SqlLiteInMemoryProductControllerTest()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options)
        {
            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();
            
            return connection;
        }

        public void Dispose() => _connection.Dispose();
    }
    #endregion
}