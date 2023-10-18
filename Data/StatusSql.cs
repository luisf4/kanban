
using Microsoft.Data.SqlClient;

public class StatusSql : Database, IStatusData
{
    public void Create(Status status)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "INSERT INTO Status VALUES (@name)";

        cmd.Parameters.AddWithValue("@name", status.Name);

        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "DELETE FROM Status WHERE StatusId = @id";

        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }

    public List<Status> Read()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM Status";

        SqlDataReader reader = cmd.ExecuteReader();

        List<Status> lista = new List<Status>();

        while(reader.Read())
        {
            Status status = new Status();
            status.StatusId = reader.GetInt32(0);
            status.Name = reader.GetString(1);

            lista.Add(status);
        }
        return lista;
    }

    public List<Status> Read(string search)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM Status WHERE Name LIKE @name";

        cmd.Parameters.AddWithValue("@name", "%" + search + "%");

        SqlDataReader reader = cmd.ExecuteReader();

        List<Status> lista = new List<Status>();

        while(reader.Read())
        {
            Status status = new Status();
            status.StatusId = reader.GetInt32(0);
            status.Name = reader.GetString(1);

            lista.Add(status);
        }
        return lista;
    }

    public Status Read(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM Status WHERE StatusId = @id";

        // EVITA SQL INJECTION!
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        if(reader.Read())
        {
            Status status = new Status();
            status.StatusId = reader.GetInt32(0);
            status.Name = reader.GetString(1);

            return status;
        }

        return null;
    }

    public void Update(int id, Status status)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = @"UPDATE Status
         SET Name = @name WHERE StatusId = @id";

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", status.Name);

        cmd.ExecuteNonQuery();
    }
}