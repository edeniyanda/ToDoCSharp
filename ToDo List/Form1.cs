using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_List
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbtitle.Text = "";
            tbdescription.Text = "";
        }

        DataTable todoList = new DataTable();
        bool  editable = false;

        private void ToDoList_Load(object sender, EventArgs e)
        {
            // Create Colomns
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            // Point Grid to the Datatable
            todogridview.DataSource = todoList;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            editable = true;

            tbtitle.Text = todoList.Rows[todogridview.CurrentCell.RowIndex].ItemArray[0].ToString();
            tbdescription.Text = todoList.Rows[todogridview.CurrentCell.RowIndex].ItemArray[0].ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[todogridview.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception error" + ex);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(editable)
            {
                todoList.Rows[todogridview.CurrentCell.RowIndex]["Title"] = tbtitle.Text;
                todoList.Rows[todogridview.CurrentCell.RowIndex]["Description"] = tbdescription.Text;
            }
            else
            {
                todoList.Rows.Add(tbtitle.Text, tbdescription.Text);
                
            }
            tbtitle.Text = "";
            tbdescription.Text = "";
            editable = false;
        }
    }
}
