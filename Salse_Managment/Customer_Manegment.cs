using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salse_Managment
{
    public partial class Customer_Manegment : XtraForm
    {
        public Customer_Manegment()
        {
            InitializeComponent();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// take incetence from class database and create table(tbl)
        /// </summary>
        Database db = new Database();
        DataTable tbl = new DataTable();
        /// <summary>
        /// Dynamic row
        /// </summary>
        public int ROW()
        {
            int row =Convert.ToInt32( txtID.Text);
            return row;
        }
        /// <summary>
        /// this method clear all data from textBox
        /// </summary>
        public void Clear()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";
            txtNote.Text = "";
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
        }
        /// <summary>
        /// this method autoNumber
        /// </summary>
        private void autoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select max(Cust_id)from Customers","");
            //vailedation text
            if ((tbl.Rows[0][0].ToString() == DBNull.Value.ToString()))
            {
                txtID.Text = "1";
            }
            else
            {
                txtID.Text=(Convert.ToInt32( tbl.Rows[0][0])+1).ToString();
            }
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            Clear();
        }
        /// <summary>
        /// this method first navigation arrow
        /// </summary>
        private void ShowData()
        {
            tbl.Clear();
            tbl = db.readData("select * from Customers","");
            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لايوجد بينات لعرضها","تاكيد");
            }
            else
            {
                txtID.Text =( tbl.Rows[0][0]).ToString();
                txtName.Text = (tbl.Rows[0][1]).ToString();
                txtPhone.Text = (tbl.Rows[0][2]).ToString();
                txtNote.Text=(tbl.Rows[0][3]).ToString();
                txtAddress.Text =(tbl.Rows[0][4]).ToString();
            }
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
        }
        //private void DynamicShowData()
        //{
        //    tbl.Clear();
        //    tbl = db.readData("select * from Customers", "");
        //    if (tbl.Rows.Count <= 0)
        //    {
        //        MessageBox.Show("لايوجد بينات لعرضها", "تاكيد");
        //    }
        //    string testing = (Convert.ToInt32(tbl.Rows[0][ROW()])).ToString();
        //    if (testing == "")
        //    {
        //        txtID.Text = "1";
        //    }
        //    else
        //    {
        //        txtID.Text = (Convert.ToInt32(tbl.Rows[0][ROW()]) - 1).ToString();
        //    }
            
            
        //    btnAdd.Enabled = false;
        //    btnNew.Enabled = true;
        //    btnUpdate.Enabled = true;
        //    btnDelete.Enabled = true;
        //    btnDeleteAll.Enabled = true;
        //}
        /// <summary>
        /// this method insert
        /// </summary>
        private void insertCustomers()
        {
            string inserttable = "insert into Customers Values("+txtID.Text+",'"+txtName.Text+"','"+txtPhone.Text+"','"+txtAddress.Text+"','"+txtNote.Text+"')";
            string mesage = "تمت الاضافة بنجاح";
            if (txtName.Text==""||txtPhone.Text==""||txtNote.Text==""||txtAddress.Text=="")
            {
                MessageBox.Show("من فضلك ادخل البيانات كامله");
            }
            else
            {
                db.excutData(inserttable, mesage);
            }
            
            autoNumber();
        }
        /// <summary>
        /// this method delete
        /// </summary>
        private void deleteCustomers()
        {
            string deletetable = "delete from Customers where Cust_id=(" + txtID.Text + ")";
            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لايوجد بينات لحذفها", "تاكيد");
            }
            else
            {
                string mesage = "تم الحذف بنجاح";
                db.excutData(deletetable, mesage);
            }
            
            autoNumber();
        }
        private void deleteAllCustomers()
        {
            string deletetable = "delete from Customers";
            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لايوجد بينات لحذفها", "تاكيد");
            }
            else
            {
                string mesage = "تم حذف الكل بنجاح";
                db.excutData(deletetable, mesage);
            }

            autoNumber();
        }
        private void update()
        {
            string inserttable = "update  Customers set Cust_Name='" + txtName.Text+"',Cust_Phone='"+txtPhone.Text+"',Cust_Address='"+txtAddress.Text+"',Notes='"+txtNote.Text+"' ";
            string mesage = "تمت التعديل بنجاح";
           
                db.excutData(inserttable, mesage);
            
        }
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customer_Manegment_Load(object sender, EventArgs e)
        {
            autoNumber();
        }
        /// <summary>
        /// btn add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            insertCustomers();
        }
        /// <summary>
        /// btn clear all data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            autoNumber();
        }
        /// <summary>
        ///btn first navigation arrow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            //DynamicShowData();
        }
        /// <summary>
        /// btn delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteCustomers();
        }
        /// <summary>
        /// btn delete all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            deleteAllCustomers();
        }
        /// <summary>
        /// btn update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}