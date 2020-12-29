using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Бипит_8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Button2_Click(sender, e);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (Arenda_bookContext db = new Arenda_bookContext())
            {
                foreach (GridViewRow rowInGrid in GridView1.Rows)
                {
                    CheckBox checkBox = (CheckBox)rowInGrid.FindControl("CheckBox1");
                    if (checkBox != null && checkBox.Checked)
                    {
                        int id = int.Parse(GridView1.Rows[rowInGrid.RowIndex].Cells[1].Text);
                        Arenda_book delId = db.Arenda_book.Where(s => s.Id == id).FirstOrDefault();
                        if (delId != null)
                        {
                            db.Arenda_book.Remove(delId);
                            db.SaveChanges();
                        }
                    }
                }
                Response.Redirect("WebForm1.aspx");
            }               
        }     

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                DataTable T_A_book = new DataTable();
                if (T_A_book.Columns.Count == 0)
                {
                    T_A_book.Columns.Add("Код", typeof(int));
                    T_A_book.Columns.Add("Книга", typeof(string));
                    T_A_book.Columns.Add("ФИО", typeof(string));
                    T_A_book.Columns.Add("Дата взятия", typeof(DateTime));
                    T_A_book.Columns.Add("Дата возрата", typeof(DateTime));
                }

                using (Arenda_bookContext db = new Arenda_bookContext())
                {
                    foreach (Arenda_book app in db.Arenda_book)
                    {
                        DataRow row = T_A_book.NewRow();
                        row[0] = app.Id;

                        using (BookContext db1 = new BookContext())
                        {
                            row[1] = db1.Book.Where(s => s.Id == app.id_book).FirstOrDefault().Name_book;
                        }

                        using (FIOContext db2 = new FIOContext())
                        {
                            row[2] = db2.FIO.Where(p => p.Id == app.id_fio).FirstOrDefault().Fio;
                        }
                        string[] d = app.Data_1.ToString().Split(' ');
                        string[] dd = app.Data_2.ToString().Split(' ');
                        row[3] = d[0];
                        row[4] = dd[0];
                        T_A_book.Rows.Add(row);
                    }
                    GridView1.DataSource = T_A_book;
                    GridView1.DataBind();
                }
            }
            else if (TextBox1.Text != "" || TextBox2.Text != "")
            {
                DateTime data_1 = DateTime.Parse(TextBox1.Text);
                DateTime data_2 = DateTime.Parse(TextBox2.Text);
                DataTable T_A_book = new DataTable();
                if (T_A_book.Columns.Count == 0)
                {
                    T_A_book.Columns.Add("Код", typeof(int));
                    T_A_book.Columns.Add("Книга", typeof(string));
                    T_A_book.Columns.Add("ФИО", typeof(string));
                    T_A_book.Columns.Add("Дата взятия", typeof(DateTime));
                    T_A_book.Columns.Add("Дата возрата", typeof(DateTime));
                }

                using (Arenda_bookContext db = new Arenda_bookContext())
                {
                    foreach (Arenda_book app in db.Arenda_book)
                    {
                        if ((app.Data_1 >= data_1 && app.Data_1 <= data_2) || (app.Data_2 >= data_1 && app.Data_2 <= data_2))
                        {
                            DataRow row = T_A_book.NewRow();
                            row[0] = app.Id;

                            using (BookContext db1 = new BookContext())
                            {
                                row[1] = db1.Book.Where(s => s.Id == app.id_book).FirstOrDefault().Name_book;
                            }

                            using (FIOContext db2 = new FIOContext())
                            {
                                row[2] = db2.FIO.Where(p => p.Id == app.id_fio).FirstOrDefault().Fio;
                            }
                            string[] date_1 = app.Data_1.ToString().Split(' ');
                            string[] date_2 = app.Data_2.ToString().Split(' ');
                            row[3] = date_1[0];
                            row[4] = date_2[0];
                            T_A_book.Rows.Add(row);
                        }
                    }
                    GridView1.DataSource = T_A_book;
                    GridView1.DataBind();
                }
            }
        }
    }
}