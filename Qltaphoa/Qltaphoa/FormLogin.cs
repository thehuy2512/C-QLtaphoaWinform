using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Qltaphoa;

namespace QLtaphoa
{
    public partial class FormLogin : Form
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-CUNAA3I\\SQLEXPRESS; Initial Catalog=QLtaphoa; UID=sa; PWD=123;");
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text=="" || txtPassword.Text=="") {
                    if (string.IsNullOrEmpty(txtUsername.Text))
                    {
                        MessageBox.Show("Bạn chưa nhập Username / Tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Focus();
                        
                    }
                    if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Bạn chưa nhập Password / Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                        
                    }
                }
                else
                {
                    String sql = "SELECT* FROM tblAccount WHERE Username = @Name and Password = @Pass";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    // SqlConnection con = new SqlConnection();
                    con.Open();
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtUsername.Text;
                    cmd.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = txtPassword.Text;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    
                    int count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        MessageBox.Show("Đăng nhập thành công !");
                        Form1 ob = new Form1();
                        ob.Show();
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                         
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra Username or Password");
                    }
                    con.Close();
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

           


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            } 
                
        }

        private void labTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
