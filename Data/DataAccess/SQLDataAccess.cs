using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using ReactNetAPI.Controllers;

namespace ReactNetAPI.Data.DataAccess
{
    /// <summary>
    /// Author Oujun Xu
    /// Class containing different methods/ functions to access and insert data to database.
    /// </summary>
    public class SQLDataAccess
    {

        /**
         * Used as load function (delete and get functions).
         * @param sql queries for update of data stored inside the db.
         */
        //public static DataTable LoadData(string sql, string connectionString)
        //{        
        //    DataTable table = new DataTable();
        //    SqlDataReader myReader;
        //    using (SqlConnection cnn = new SqlConnection(connectionString))
        //    {
        //        cnn.Open();
        //        using (SqlCommand myCommand = new SqlCommand(sql, cnn))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader); 
        //            myReader.Close();
        //            cnn.Close();
        //        }
        //    }
        //    return table;
        //}

        public static List<T> LoadData<T>(string sql, string connectionString)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                return cnn.Query<T>(sql).ToList(); 
            }
        }



        /**
         * Used as save function (insert to database).
         * @param sql queries for update of data stored inside the db.
         * @param data, also called the model in this case.
         */
        public static int SaveData<T>(string sql, T data, string connectionString)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                return cnn.Execute(sql, data);
            }
        }

        /**
         * Used as a update function.
         * @param sql queries for update of data stored inside the db.
         * @param data, also called the model in this case.
         */
        public static List<T> UpdateData<T>(string sql, T data, string connectionString)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {

                return cnn.Query<T>(sql, data).ToList();
            }
        }
    }
}
