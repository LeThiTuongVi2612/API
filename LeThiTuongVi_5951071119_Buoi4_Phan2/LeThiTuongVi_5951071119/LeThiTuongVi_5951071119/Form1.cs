using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeThiTuongVi_5951071119
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetStudentRecord();
        }

        
        

        private void GetStudentRecord()
        {
            //ket noi DB
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=DemoCRUD;Integrated Security=True");

            //Truy van DB
            SqlCommand cmd = new SqlCommand("Select * from StudentTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StudentRecordData.DataSource = dt;
        }

        private bool IsValiData()
        {
            if (txtHName.Text == string.Empty || txtNName.Text == string.Empty || txtAdress.Text == string.Empty || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtRoll.Text))
            {
                MessageBox.Show("Có chỗ chưa nhập dữ liệu!", "Lỗi dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=DemoCRUD;Integrated Security=True");
            if (IsValiData())
            {
                //ket noi DB
                
                SqlCommand cmd = new SqlCommand("insert into StudentTb Values" + "(@Name, @FatherName, @RollNumber, @Address, @Mobile)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtNName);
                cmd.Parameters.AddWithValue("@FatherName", txtHName);
                cmd.Parameters.AddWithValue("@RollNumber", txtRoll);
                cmd.Parameters.AddWithValue("@Address", txtAdress);
                cmd.Parameters.AddWithValue("@Mobile", txtPhone);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecord();
            }
        }

        public int StudentID;
        private void StudentRecordData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(StudentRecordData.Rows[0].Cells[0].Value);
            txtHName.Text = StudentRecordData.SelectedRows[0].Cells[1].Value.ToString();
            txtNName.Text = StudentRecordData.SelectedRows[0].Cells[2].Value.ToString();
            txtRoll.Text = StudentRecordData.SelectedRows[0].Cells[3].Value.ToString();
            txtAdress.Text = StudentRecordData.SelectedRows[0].Cells[4].Value.ToString();
            txtPhone.Text = StudentRecordData.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=DemoCRUD;Integrated Security=True");
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE StudentTb SET" + "Name = @Name, FatherName = @FatherName," + "RollNumber = @RollNumber, Address = @Address," + "Mobile = @Mobile WHERE StudentID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtNName);
                cmd.Parameters.AddWithValue("@FatherName", txtHName);
                cmd.Parameters.AddWithValue("@RollNumber", txtRoll);
                cmd.Parameters.AddWithValue("@Address", txtAdress);
                cmd.Parameters.AddWithValue("@Mobile", txtPhone);
                cmd.Parameters.AddWithValue("@ID", this.StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecord();
                ResetData();

            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi !!!", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ResetData()
        {
            txtHName.Text = txtNName.Text = txtAdress.Text = txtPhone.Text = txtRoll.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=DemoCRUD;Integrated Security=True");
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE StudentTb SET" + "Name = @Name, FatherName = @FatherName," + "RollNumber = @RollNumber, Address = @Address," + "Mobile = @Mobile WHERE StudentID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecord();
                ResetData();
            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi !!!", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
