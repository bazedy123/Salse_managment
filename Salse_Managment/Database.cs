using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace Salse_Managment
{
    class Database
    {
       /// <summary>
       /// connction database
       /// </summary>
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Salesdb;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        /// <summary>
        /// this method read from database
        /// </summary>
        /// <param name="stat">varaible statment select</param>
        /// <returns></returns>
        public DataTable readData(string stat,string mesage)
        {
            DataTable tbl = new DataTable();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = stat;
                con.Open();
                //table from database
                tbl.Load(cmd.ExecuteReader());
                con.Close();
                if (mesage != "")
                {
                    mesage = MessageBox.Show(mesage, "تاكيد", MessageBoxButtons.OK).ToString();
                }
            
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
            return tbl;
        }
        /// <summary>
        /// this method excuteData in database insert delete delete all and update
        /// </summary>
        /// <returns></returns>
        public bool excutData(string stat,string mesage)
        {
            try
            {
                cmd.Connection = con;
                cmd.CommandText = stat;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
               
                if (mesage !="")
                {
                   mesage = MessageBox.Show(mesage,"تاكيد",MessageBoxButtons.OK).ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
           
        }
    }
}
