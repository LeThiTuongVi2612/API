using _5951071119_LeThiTuongVi_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _5951071119_LeThiTuongVi_Nhom3.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers:"*",methods:"*")]
    public class StudentController : ApiController
    {
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            _conn = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=Nawab;Integrated Security=True");
            DataTable dt = new DataTable();
            var query = "select * from Student";
            _adapter = new SqlDataAdapter {
                SelectCommand = new SqlCommand(query, _conn) };
            _adapter.Fill(dt);
            List<Student> students = new List<Student>(dt.Rows.Count);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow studentReecord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentReecord));
                }
            }
            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
            _conn = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=Nawab;Integrated Security=True");
            DataTable dt = new DataTable();
            var query = "select * from Student where id = " + id;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adapter.Fill(dt);
            List<Student> students = new List<Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentReecord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentReecord));
                }
            }
            return students;
        }

        // POST api/<controller>
        public string Post([FromBody] createStudent value)
        {
            _conn = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=Nawab;Integrated Security=True");
            var query = "insert into Student (f_name, m_name, l_name, address, birthDate, score) values (@f_name, @m_name, @l_name, @address, @birthDate, @score)";
            SqlCommand insertCommand = new SqlCommand(query, _conn);
            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if(result > 0)
            {
                return "Them thanh cong";

            }
            else
            {
                return "Them that bai";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] createStudent value)
        {
            _conn = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=Nawab;Integrated Security=True");
            var query = "update Student set f_name = @f_name, m_name = @m_name, l_name = @l_name, address = @address, birthDate = @birthDate, score = @score where Id=" + id;
            SqlCommand insertCommand = new SqlCommand(query, _conn);
            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Sua thanh cong";

            }
            else
            {
                return "Sua that bai";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            _conn = new SqlConnection("Data Source=LAPTOP-S31L3KUJ\\SQLEXPRESSVI;Initial Catalog=Nawab;Integrated Security=True");
            var query = "delete from Student where Id=" + id;
            SqlCommand insertCommand = new SqlCommand(query, _conn);
            

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Xoa thanh cong";

            }
            else
            {
                return "Xoa that bai";
            }
        }
    }
}