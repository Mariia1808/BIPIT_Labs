using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Бипит_8
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (Arenda_bookContext db = new Arenda_bookContext())
            {
                Arenda_book app = new Arenda_book()
                {
                    id_book = int.Parse(DropDownList1.Text),
                    id_fio = int.Parse(DropDownList2.Text),
                    Data_1 = DateTime.Parse(TextBox1.Text),
                    Data_2 = DateTime.Parse(TextBox2.Text)
                };
                db.Arenda_book.Add(app);
                db.SaveChanges();
            }
            Response.Redirect("WebForm1.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                using (FIOContext db = new FIOContext())
                {
                    DataTable T_fio = new DataTable();
                    if (T_fio.Columns.Count == 0)
                    {
                        T_fio.Columns.Add("Id", typeof(int));
                        T_fio.Columns.Add("Fio", typeof(string));
                    }
                    foreach (FIO p in db.FIO)
                    {
                        DataRow row = T_fio.NewRow();
                        row[0] = p.Id;
                        row[1] = p.Fio;
                        T_fio.Rows.Add(row);
                    }
                    DropDownList2.DataSource = T_fio;
                    DropDownList2.DataTextField = "Fio";
                    DropDownList2.DataValueField = "Id";
                    DropDownList2.DataBind();
                }

                using (BookContext db = new BookContext())
                {
                    DataTable T_book = new DataTable();
                    if (T_book.Columns.Count == 0)
                    {
                        T_book.Columns.Add("Id", typeof(int));
                        T_book.Columns.Add("Name_book", typeof(string));
                    }
                    foreach (Book s in db.Book)
                    {
                        DataRow row = T_book.NewRow();
                        row[0] = s.Id;
                        row[1] = s.Name_book;
                        T_book.Rows.Add(row);
                    }
                    DropDownList1.DataSource = T_book;
                    DropDownList1.DataTextField = "Name_book";
                    DropDownList1.DataValueField = "Id";
                    DropDownList1.DataBind();
                }               
            }          
        }        
    }
}