using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;


namespace enviriomentMeasurement
{
    class sqlEngin
    {
        MySqlConnection mysqlConnection;
        DataSet dataSet;
        string IP = "localhost";
        string UserName = "root";
        string Password = "oxful@8848";
        string Database = "measuring";
        /// <summary>
        /// 建立mysql连接
        /// </summary>
        public sqlEngin()
        {
            try
            {
                mysqlConnection = new MySqlConnection("datasource=" + IP + ";username=" + UserName + ";password=" + Password + ";database=" + Database + ";charset=utf8");
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public sqlEngin(string IP, string UserName, string Password, string Database)
        {
            try
            {
                string connectionString = "datasource=" + IP + ";username=" + UserName + ";password=" + Password + ";database=" + Database + ";charset=gb2312";
                mysqlConnection = new MySqlConnection(connectionString);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string MysqlInfo()
        {
            string mysqlInfo = null;
            try
            {
                mysqlConnection.Open();
                mysqlInfo += "Connection Opened." + Environment.NewLine;
                mysqlInfo += "Connection String:" + mysqlConnection.ConnectionString.ToString() + Environment.NewLine;
                mysqlInfo += "Database:" + mysqlConnection.Database.ToString() + Environment.NewLine;
                mysqlInfo += "Connection ServerVersion:" + mysqlConnection.ServerVersion.ToString() + Environment.NewLine;
                mysqlInfo += "Connection State:" + mysqlConnection.State.ToString() + Environment.NewLine;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySqlException Error:" + ex.ToString());
            }
            finally
            {
                mysqlConnection.Close();
            }
            return mysqlInfo;
        }
        /// <summary>
        /// 执行sql语句无返回结果
        /// </summary>
        public int MysqlCommand(string MysqlCommand)
        {
            try
            {
                mysqlConnection.Open();
                Console.WriteLine("MysqlConnection Opened.");
                MySqlCommand mysqlCommand = new MySqlCommand(MysqlCommand, mysqlConnection);
                return mysqlCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySqlException Error:" + ex.ToString());
                if (Regex.IsMatch(ex.ToString(), ""))
                {
                    Console.WriteLine(ex.Message);
                }
            }
            finally
            {
                mysqlConnection.Close();
            }
            return -1;
        }

        /// <summary>
        /// 执行select 语句返回执行结果
        /// </summary>
        public DataView MysqlDataAdapter(string table)
        {
            DataView dataView = new DataView();
            try
            {
                mysqlConnection.Open();
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter("Select * from " + table, mysqlConnection);
                dataSet = new DataSet();
                mysqlDataAdapter.Fill(dataSet, table);
                dataView = dataSet.Tables[table].DefaultView;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }
            return dataView;
        }

        /// <summary>
        /// 执行select 语句返回执行结果
        /// </summary>
        public DataView ExecuteDataView(string sql)
        {
            DataView dataView = new DataView();
            try
            {
                mysqlConnection.Open();
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter(sql, mysqlConnection);
                dataSet = new DataSet();
                mysqlDataAdapter.Fill(dataSet);
                dataView = dataSet.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                mysqlConnection.Close();
            }
            finally
            {
                mysqlConnection.Close();
            }
            return dataView;
        }


        /// <summary>  
        /// 需要获得多个结果集的时候用该方法，返回DataSet对象。  
        /// </summary>  
        /// <param name="sql语句"></param>  
        /// <returns></returns>  

        public DataSet ExecuteDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                //数据适配器  
                mysqlConnection.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, mysqlConnection);

                
                sqlda.Fill(ds);
                return ds;
                //不需要打开和关闭链接.  
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                mysqlConnection.Close();
            }
            finally
            {
                mysqlConnection.Close();
            }
            return ds;
        }


        /// <summary>
        /// 统计记录个数 参数：select count(*) from isns_users
        /// </summary>
        public long MysqlCountRow(string sql)
        {
            DataView dataView = new DataView();
            try
            {
                mysqlConnection.Open();

                MySqlCommand mycm = new MySqlCommand(sql, mysqlConnection);
                // MySqlDataReader msdr = mycm.ExecuteReader();
                long recordCount = (long)mycm.ExecuteScalar();
                return recordCount;
            }
            catch (MySqlException)
            {
                return -1;
                // Console.WriteLine(ex.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }
            // return 0;
        }
    }//end class
}