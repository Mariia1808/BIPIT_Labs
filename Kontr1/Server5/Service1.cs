using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Server5
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        string path = @"workstation id=bipitkr.mssql.somee.com;packet size=4096;user id=D98512416_SQLLogin_1;pwd=5vem21popc;data source=bipitkr.mssql.somee.com;persist security info=False;initial catalog=bipitkr";

        public DataSet GetTex_obslysh()
        {
            string query = "SELECT ID_TEX_OBSLYSH as 'Код ', Data_time as 'Дата и время', Avtor as 'Автор', Opisanie as 'Описание проблемы' FROM Tex_obslysh ";
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds, "Tex_obslysh");
                return ds;
            }
        }

        public void Insert(string d1, string d2, string d3)
        {
            string query = $"INSERT INTO Tex_obslysh VALUES ('{d1}','{d2}','{d3}')";
            var connect = new SqlConnection(path);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}
