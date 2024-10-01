using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;  // đầu tiên chọn phép cộng

            // Thêm sự kiện Leave cho các ô nhập dữ liệu
            txtSo1.Leave += TxtSo_Leave;
            txtSo2.Leave += TxtSo_Leave;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có phải số nguyên lớn không
            if (IsBigInteger(txtSo1.Text) && IsBigInteger(txtSo2.Text))
            {
                // Lấy giá trị của 2 ô số 
                BigInteger bigInt1, bigInt2, bigIntKQ = 0;
                bigInt1 = BigInteger.Parse(txtSo1.Text);
                bigInt2 = BigInteger.Parse(txtSo2.Text);
        
                // Kiểm tra chia cho 0
                if (radChia.Checked && bigInt2 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSo2.Focus(); // Quay lại ô nhập số chia
                    return;
                }
        
                // Thực hiện phép tính dựa vào phép toán được chọn
                if (radCong.Checked) bigIntKQ = bigInt1 + bigInt2;
                else if (radTru.Checked) bigIntKQ = bigInt1 - bigInt2;
                else if (radNhan.Checked) bigIntKQ = bigInt1 * bigInt2;
                else if (radChia.Checked) bigIntKQ = bigInt1 / bigInt2;
        
                // Hiển thị kết quả lên ô kết quả
                txtKq.Text = bigIntKQ.ToString();
            }
            else
            {
                // Lấy giá trị của 2 ô số
                decimal so1, so2, kq = 0;
                so1 = decimal.Parse(txtSo1.Text);
                so2 = decimal.Parse(txtSo2.Text);
        
                // Kiểm tra chia cho 0
                if (radChia.Checked && so2 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSo2.Focus(); // Quay lại ô nhập số chia
                    return;
                }
        
                // Thực hiện phép tính dựa vào phép toán được chọn
                if (radCong.Checked) kq = so1 + so2;
                else if (radTru.Checked) kq = so1 - so2;
                else if (radNhan.Checked) kq = so1 * so2;
                else if (radChia.Checked) kq = so1 / so2;
        
                // Hiển thị kết quả lên ô kết quả
                txtKq.Text = kq.ToString();
            }
        }


        private void txtSo2_Click(object sender, EventArgs e)
        {
            txtSo2.SelectAll();
        }

        private bool IsBigInteger(string input)
        {
            BigInteger temp;
            return BigInteger.TryParse(input, out temp);
        }

        // Hàm kiểm tra xem chuỗi nhập vào có phải là số hợp lệ (bao gồm cả số nguyên và số thực)
        private bool IsValidNumber(string input)
        {
            decimal temp;
            return decimal.TryParse(input, out temp);
        }

        private void TxtSo_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu ô nhập dữ liệu trống hoặc không phải là số hợp lệ
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("Ô nhập dữ liệu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus(); // Quay lại ô nhập dữ liệu
                textBox.Text = "0";
            }

            if (!IsValidNumber(textBox.Text))
            {
                MessageBox.Show("Dữ liệu phải là số !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus(); // Quay lại ô nhập dữ liệu
                textBox.Text = "0";
            }    
        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            txtSo1.SelectAll();
        }
    }
}
