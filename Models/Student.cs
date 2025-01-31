using Microsoft.Data.SqlClient;
using System.Data;

namespace day2_wk.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stu_new;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trusted_Connection=True;");

        // without refresh page 
        public List<Student> getData(string Id)
        { 
            List<Student> lsStu= new List<Student>();
            string query = "select * from stu1";
            if (!string.IsNullOrWhiteSpace(Id))
            {
                query = "select * from stu1 where Id=" + Id;
            }
            SqlDataAdapter adt = new SqlDataAdapter(query,connection);
            DataSet ds= new DataSet();
            adt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lsStu.Add(new Student {
                    Id = Convert.ToInt32(dr["id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    Age = Convert.ToInt32(dr["Age"].ToString())
                });
            }
            return lsStu;
        }
        // insert
        public bool insert(Student Stu)
        {
            if (Stu.Name != string.Empty && Stu.Email != string.Empty && Stu.Age >= 0)
            {
                SqlCommand cmd = new SqlCommand("insert into stu1 values(@Name,@Email,@Age)", connection);
                cmd.Parameters.AddWithValue("@Name", Stu.Name);
                cmd.Parameters.AddWithValue("@Email", Stu.Email);
                cmd.Parameters.AddWithValue("@Age", Stu.Age);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        //update
        public bool update(Student Stu)
        {
            if ( Stu.Name != string.Empty && Stu.Email != string.Empty && Stu.Age >= 0)
            {
                string query = "UPDATE stu1 SET Name=@Name, Email=@Email, Age=@Age WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", Stu.Name);
                cmd.Parameters.AddWithValue("@Email", Stu.Email);
                cmd.Parameters.AddWithValue("@Age", Stu.Age);
                cmd.Parameters.AddWithValue("@Id", Stu.Id);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        //delete
        public bool delete(Student Stu)
        {
            string query = "DELETE FROM stu1 WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", Stu.Id);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
    }

}
