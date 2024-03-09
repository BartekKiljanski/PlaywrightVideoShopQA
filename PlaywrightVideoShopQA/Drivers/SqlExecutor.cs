using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightVideoShopQA.Drivers
{
	public class SqlExecutor
	{
		private readonly string _connectionString;

		public SqlExecutor(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task ExecuteSqlStringAsync(string queryString, object parameters)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync();
				await connection.ExecuteAsync(queryString, parameters);
			}
		}
	}
}