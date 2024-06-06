using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUi.AdoSample
{
    public class SqlSample
    {
        private SqlConnection connection;
        public SqlSample()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "OnlineShopDb";
            builder.IntegratedSecurity = true;
            builder.Encrypt = false;
            connection = new(builder.ConnectionString);

        }
        public void FirstSample()
        {
            string connectionString = "Server=.; Initial Catalog=OnlineShopDb; Integrated Security=True;Encrypt=false";

            SqlConnection connection = new(connectionString);

            SqlCommand command = connection.CreateCommand();

            //command.CommandType = CommandType.Text;

            command.CommandText = "select * from Categories";

            connection.Open();

            var data = command.ExecuteReader();

            while (data.Read())
            {
                Console.WriteLine($"{data[1]}");
                Console.WriteLine($"{data["Id"]} {data["CategoryName"]}");
            }

            connection.Close();

            Console.ReadKey();
        }

        /// <summary>
        /// اطلاعاتی راجب اتصال می دهد
        /// </summary>
        public void WorkWithConnection()
        {
            string connectionString = "Server=.; Initial Catalog=OnlineShopDb; Integrated Security=True;Encrypt=false";

            SqlConnection connection = new(connectionString);

            Console.WriteLine(connection.Database);
            Console.WriteLine(connection.CommandTimeout);
            Console.WriteLine(connection.ConnectionTimeout);
            Console.WriteLine(connection.DataSource);
        }

        public void ConnectionBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.IntegratedSecurity = true;
            builder.DataSource = ";";
            builder.Encrypt = false;
            builder.CommandTimeout = 100;
            builder.InitialCatalog = "OnlineShopDb";

            SqlConnection connection = new(builder.ConnectionString);
        }

        public void TestCommand()
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = "select * from Categories"
            };

            connection.Open();
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Id"]);
            }
        }

        public void TestReader()
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = "select * from Categories"
            };

            connection.Open();
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i));
                }

                Console.WriteLine(reader["Id"]);
            };
            connection.Close();
        }

        public void TestReaderMultiple()
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = "select * from Categories;select * from Products"
            };

            connection.Open();
            var reader = sqlCommand.ExecuteReader();

            do
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader.GetName(i));
                        Console.WriteLine(reader.GetValue(i));
                    }

                    Console.WriteLine(reader["Id"]);
                };
            } while (reader.NextResult());
        }

        public void AddProduct(int categoryId, string description, int price)
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = $"insert into products(CategoryId,Description,Price) Values({categoryId},'{description}','{price}')"
            };

            connection.Open();
            int result = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(result);
        }

        public void AddProductParameter(int categoryId, string description, int price)
        {
            SqlParameter categoryIdParam = new()
            {
                ParameterName = "@CategoryId",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                Value = categoryId
            };
            SqlParameter productDescription = new()
            {
                ParameterName = "@Description",
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input,
                Value = description
            };
            SqlParameter productPrice = new()
            {
                ParameterName = "@Price",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Input,
                Value = price
            };

            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = $"insert into products(CategoryId,Description,Price) Values(@CategoryId,@Description,@Price)"
            };
            sqlCommand.Parameters.Add(categoryIdParam);
            sqlCommand.Parameters.Add(productDescription);
            sqlCommand.Parameters.Add(productPrice);
            connection.Open();
            int result = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(result);
        }

        public void AddTransaction(string cName, int categoryId, string description, int price)
        {
            SqlTransaction transaction = null;

            SqlCommand addCat = new SqlCommand()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = $"insert into Categories(CategoryName) Values('{cName}')"
            };
            SqlCommand addPro = new SqlCommand()
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = $"insert into products(CategoryId,Description,Price) Values({categoryId},'{description}','{price}')"
            };
            connection.Open();
            try
            {
                transaction = connection.BeginTransaction();
                int res = addCat.ExecuteNonQuery();
                res += addPro.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }

        }

        public void SimpleBulkInsert()
        {
            SqlCommand sqlCommand = new()
            {
                CommandType = System.Data.CommandType.Text,
                Connection = connection,
            };
            connection.Open();
            Stopwatch stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                sqlCommand.CommandText = $"Insert into BulkTable(Name,[Desc]) Values('Name {i}','Desc {i}')";
                sqlCommand.ExecuteNonQuery();
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedMilliseconds);
        }

        public void SimpleBulk()
        {
            SqlBulkCopy sqlBulk = new SqlBulkCopy(connection);
            sqlBulk.DestinationTableName = "BulkTable";
            
            connection.Open();
            Stopwatch startWatch = Stopwatch.StartNew();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("Desc"));
            for (int i = 0; i < 1000; i++)
            {
                dt.Rows.Add(new object[] { $"Name {i}",$"Desc {i}" });
            }
            sqlBulk.WriteToServer(dt);
            startWatch.Stop();
            Console.WriteLine(startWatch.ElapsedMilliseconds);
        }
    }
}
