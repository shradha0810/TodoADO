using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ToADO.Models
{
    public class TodoDBRepository
    {
        public List<Todos> GetTodos()
        {
            List<Todos> todos = new List<Todos>();
            string cs = "Data Source=LAPTOP-5CVMLAO2\\SQLEXPRESS;Initial Catalog=Tododb;Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetTodoList",con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Todos todo = new Todos()
                {
                    id = Convert.ToInt32(dr.GetValue(0).ToString()),
                    Title=dr.GetValue(1).ToString(),
                    Item=dr.GetValue(2).ToString()
                };

                todos.Add(todo);
            }

            con.Close();

            return todos;
        }

        public bool AddTodo(Todos todo)
        {
            string cs = "Data Source=LAPTOP-5CVMLAO2\\SQLEXPRESS;Initial Catalog=Tododb;Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddTodo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", todo.Title);
            cmd.Parameters.AddWithValue("@item", todo.Item);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)

            {
                return true;
            }

            return false;
        }

        public bool EditTodo(int id,Todos todo)
        {
            string cs = "Data Source=LAPTOP-5CVMLAO2\\SQLEXPRESS;Initial Catalog=Tododb;Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spEditTodo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@title", todo.Title);
            cmd.Parameters.AddWithValue("@item", todo.Item);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)

            {
                return true;
            }

            return false;
        }

        public bool DeleteTodo(int id)
        {
            string cs = "Data Source=LAPTOP-5CVMLAO2\\SQLEXPRESS;Initial Catalog=Tododb;Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteTodo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)

            {
                return true;
            }

            return false;
        }

    }
}
