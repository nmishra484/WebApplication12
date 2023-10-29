using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlTypes;
using System.Configuration;
using WebApplication12.Models;
using System.Data;

namespace WebApplication12.Repository
{
    public class DAL
    {
        private readonly IConfiguration _configuration;

        public DAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection con = new SqlConnection("Data Source = DESKTOP - B7N39K8\\SQLEXPRESS; Initial Catalog = test_mvc; Integrated Security = True");

        public List<UserRegModel> GetDataList()
        {
            List<UserRegModel> lst = new List<UserRegModel>();
            SqlCommand cmd = new SqlCommand("sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new UserRegModel
                {
                    id = Convert.ToInt32(dr[0]),
                    emailid = Convert.ToString(dr[1]),
                    password = Convert.ToString(dr[2]),
                    name = Convert.ToString(dr[3]),
                });
            }
            return lst;
        }
        public bool InsertData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            cmd.Parameters.AddWithValue("@email", ur.emailid);
            cmd.Parameters.AddWithValue("@pwd", ur.password);
            cmd.Parameters.AddWithValue("@nitesh", ur.name);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            cmd.Parameters.AddWithValue("@email", ur.emailid);
            cmd.Parameters.AddWithValue("@pwd", ur.password);
            cmd.Parameters.AddWithValue("@nitesh", ur.name);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}