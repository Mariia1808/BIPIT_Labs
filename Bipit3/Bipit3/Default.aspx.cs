using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Bipit3
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            string connect = @"Data Source=assistents.mssql.somee.com;Initial Catalog=assistents;User Id=Mariia1808_SQLLogin_1;Password=oetbuutp39";
            if (Menu1.SelectedValue.Contains("Сотрудники"))
            {
                string query = "SELECT * FROM Сотрудники";
                DataSet bd = new DataSet();
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                    sqlDataAdapter.Fill(bd, "Сотрудники");
                    GridView1.DataSource = bd.Tables["Сотрудники"];
                    GridView1.DataBind();
                }
            }
            if (Menu1.SelectedValue.Contains("Должности"))
            {
                string query = "SELECT * FROM Должности";
                DataSet bd = new DataSet();
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                    sqlDataAdapter.Fill(bd, "Должности");
                    GridView1.DataSource = bd.Tables["Должности"];
                    GridView1.DataBind();
                }
            }
            if (Menu1.SelectedValue.Contains("Назначения"))
            {

                string query = "SELECT ID_Назначения, Сотрудник, Должность, Дата_начала, Оклад , CONVERT(int, YEAR(GETDATE()) - YEAR(Дата_начала)) * 0.05 * Оклад +  Оклад as Надбавка FROM Назначения";
                DataSet bd = new DataSet();
                using (SqlConnection connection = new SqlConnection(connect))
                {

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                    sqlDataAdapter.Fill(bd, "Назначения");
                    GridView1.DataSource = bd.Tables["Назначения"];
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}