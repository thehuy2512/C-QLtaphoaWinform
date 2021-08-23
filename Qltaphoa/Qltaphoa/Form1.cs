
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qltaphoa
{
    public partial class Form1 : Form
    {
        HanghoaBLL bllHh;

        public Form1()
        {
            InitializeComponent();
            bllHh = new HanghoaBLL();

        }
        
    
        public void ShowAllHanghoa()
        {
            DataTable dt = bllHh.getAllHanghoa();
            dataGridViewHanghoa.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            ShowAllHanghoa();
        }
        public bool CheckData()
        {
            if(string.IsNullOrEmpty(txtMahang.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã hàng.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtMahang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenhang.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLoaihang.Text))
            {
                MessageBox.Show("Bạn chưa nhập loại hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaihang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDongia.Text))
            {
                MessageBox.Show("Bạn chưa nhập đơn giá hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSoluong.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Focus();
                return false;
            }
            return true;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(CheckData())
            {
                tblHanghoa Hh = new tblHanghoa();
                Hh.Mahang = txtMahang.Text;
                Hh.Tenhang = txtTenhang.Text;
                Hh.Loaihang = txtLoaihang.Text;
                Hh.Dongia = int.Parse(txtDongia.Text);
                Hh.Soluong = int.Parse(txtSoluong.Text);

                if (bllHh.InsertHanghoa(Hh))
                    ShowAllHanghoa();
                else
                    MessageBox.Show("Đã có lỗi xảy ra khi thêm, hãy thử lại ","Thông báo lỗi",MessageBoxButtons.OK,MessageBoxIcon.Stop);

            }
            txtMahang.Text = "";
            txtTenhang.Text = "";
            txtLoaihang.Text = "";
            txtDongia.Text = "";
            txtSoluong.Text = "";

        }
        int Id;
        private void dataGridViewHanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                Id = Int32.Parse(dataGridViewHanghoa.Rows[index].Cells["colId"].Value.ToString());
                txtMahang.Text = dataGridViewHanghoa.Rows[index].Cells["colMahang"].Value.ToString();
                txtTenhang.Text = dataGridViewHanghoa.Rows[index].Cells["colTenhang"].Value.ToString();
                txtLoaihang.Text = dataGridViewHanghoa.Rows[index].Cells["colLoaihang"].Value.ToString();
                txtDongia.Text = dataGridViewHanghoa.Rows[index].Cells["colDongia"].Value.ToString();
                txtSoluong.Text = dataGridViewHanghoa.Rows[index].Cells["colSoluong"].Value.ToString();

            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblHanghoa Hh = new tblHanghoa();
                Hh.Id = Id;
                Hh.Mahang = txtMahang.Text;
                Hh.Tenhang = txtTenhang.Text;
                Hh.Loaihang = txtLoaihang.Text;
                Hh.Dongia = int.Parse(txtDongia.Text);
                Hh.Soluong = int.Parse(txtSoluong.Text);

                if (bllHh.UpdateHanghoa(Hh))
                    ShowAllHanghoa();
                else
                    MessageBox.Show("Đã có lỗi xảy ra khi sửa, hãy thử lại ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xoá không?","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblHanghoa Hh = new tblHanghoa();
                Hh.Id = Id;
                

                if (bllHh.DeleteHanghoa(Hh))
                    ShowAllHanghoa();
                else
                    MessageBox.Show("Đã có lỗi xảy ra khi xoá, hãy thử lại ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }    
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string value = txtTim.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllHh.FindHanghoa(value);
                dataGridViewHanghoa.DataSource = dt;
            }
            else
                ShowAllHanghoa();

        }

        private void btnExitform1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void labTenhang_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtMahang_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
