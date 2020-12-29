using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server_1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        string path = @"Data Source=BIPIT2000.mssql.somee.com;Initial Catalog=BIPIT2000;User Id=bipit123_SQLLogin_1;Password=z892p4y8o2";
        public void DoWork()
        {

        }

        public void ConnectionInfo(string name, string port, string localPath, string uri, string scheme)
        {
            Console.WriteLine();
            Console.WriteLine("***** Host Info *****");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Port: {port}");
            Console.WriteLine($"LocalPath: {localPath}");
            Console.WriteLine($"Uri: {uri}");
            Console.WriteLine($"Scheme: {scheme}");
            Console.WriteLine("***********************************");
            Console.WriteLine();
        }

        public DataTable GetData()
        {
            string query = "SELECT * FROM Назначеия";
            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                command.Connection = connection;
                dataAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Назначеия";
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable GetComboValue()
        {
            string query = "SELECT * FROM Должности";
            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                command.Connection = connection;
                dataAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Должности";
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void NewRec(string sotr, string dolg, string date)
        {
            string query = $"INSERT INTO Назначеия ([Сотрудник], [Должность], [Дата_начала])" +
                $"VALUES ('{sotr}', '{dolg}','{date}')";
            string query1 = $"UPDATE Назначеия set Оклад = Должности.Оклад from Назначеия, Должности where Назначеия.Должность = Должности.Должность";
            string query2 = $"UPDATE Назначеия set Набавка = CONVERT(int, YEAR(GETDATE()) - YEAR(Дата_начала)) * 0.05 * Должности.Оклад + Должности.Оклад FROM Назначеия, Должности  where Должности.Должность = Назначеия.Должность";
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
        }
    }
}