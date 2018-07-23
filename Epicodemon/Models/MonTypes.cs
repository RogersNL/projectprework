using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Epicodemon.Models
{
  public class MonType
  {
    private int _monTypeId;
    private string _monTypeName;

    public MonType(string MonTypeName, int MonTypeId = 0)
    {
      _monTypeId = MonTypeId;
      _monTypeName = MonTypeName;
    }
    public int GetMonTypeId()
    {
      return _monTypeId;
    }
    public string GetMonTypeName()
    {
      return _monTypeName;
    }

    public override bool Equals(System.Object otherMonType)
    {
      if(!(otherMonType is MonType))
      {
        return false;
      }
      else
      {
        MonType newMonType = (MonType) otherMonType;
        bool idEquality = this.GetMonTypeId().Equals(newMonType.GetMonTypeId());
        bool nameEquality = this.GetMonTypeName().Equals(newMonType.GetMonTypeName());
        return (idEquality && nameEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetMonTypeId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO monTypes (name) VALUES (@monTypeName);";

      cmd.Parameters.Add(new MySqlParameter("@monTypeName", _monTypeName));

      cmd.ExecuteNonQuery();
      _monTypeId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<MonType> GetAllMonTypes()
    {
      List<MonType> allMonTypes = new List<MonType> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM monTypes;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int MonTypeId = rdr.GetInt32(0);
        string MonTypeName = rdr.GetString(1);
        MonType newMonType = new MonType(MonTypeName, MonTypeId);
        allMonTypes.Add(newMonType);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMonTypes;
      // return new List<MonType>{};
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM monTypes;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static MonType Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM monTypes WHERE id = (@searchId);";

      cmd.Parameters.Add(new MySqlParameter("@searchId", id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int MonTypeId = 0;
      string MonTypeName = "";

      while(rdr.Read())
      {
        MonTypeId = rdr.GetInt32(0);
        MonTypeName = rdr.GetString(1);
      }
      MonType newMonType = new MonType(MonTypeName, MonTypeId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      // return new MonType("", "", 0);
      return newMonType;
    }
    
    public void Edit(string newMonTypeName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE monTypes SET name = @newMonTypeName WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _monTypeId));
      cmd.Parameters.Add(new MySqlParameter("@newMonTypeName", newMonTypeName));

      cmd.ExecuteNonQuery();
      _monTypeName = newMonTypeName;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM monTypes WHERE id = @MonTypeId; DELETE FROM monTypes_books WHERE monType_id = @MonTypeId;";

      cmd.Parameters.Add(new MySqlParameter("@MonTypeId", this.GetMonTypeId()));

      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}
