using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bipit4
{
    public partial class Add1 : System.Web.UI.Page
    {
        //string path = @"Server = localhost\SQLEXPRESS; Database = Bipit3; Trusted_Connection = True";
        string path = @"Data Source=Bipit337.mssql.somee.com;Initial Catalog=Bipit337;User Id=bipit1_SQLLogin_4;Password=9j9dxyk2f2";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void NewRec()
        {
            string query = $"INSERT INTO Service ([Наименование авто], [Наименование работы], [Стоимость], [Стандартное время работы], [Фактическое время работы])" +
                $"VALUES ('{TextBox1.Text}', '{DropDownList1.SelectedValue}','', (select [Стандартное время работы] from Work where [Наименование работы] = '{DropDownList1.SelectedValue}'), '{TextBox2.Text}')";
            string query1 = @"update Service 
                            set Стоимость = [Фактическое время работы] * (Work.Стоимость/Work.[Стандартное время работы])
                            FROM Service, Work where Work.[Наименование работы]=Service.[Наименование работы]";
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (Menu1.SelectedValue.Contains("Список"))
            {
                Response.Redirect("~/List.aspx");
            }
            if (Menu1.SelectedValue.Contains("Новый"))
            {
                Response.Redirect("~/Add.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NewRec();
            Response.Redirect("~/List.aspx");
        }
    }
}