using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Epicodemon.Models
{
  public class Move
  {
    private int _moveId;
    private string _moveName;
    private int _basePower;
    private string _attackStyle;
    private string _description;
    private string _secondaryEffect;
    private int _powerPoints;

    public Move(string MoveName, int BasePower, string AttackStyle, string Description, string SecondaryEffect, int PowerPoints, int MoveId = 0)
    {
      _moveId = MoveId;
      _moveName = MoveName;
      _basepower = Basepower;
      _attackStyle = AttackStyle;
      _description = Description;
      _secondaryEffect = SecondaryEffect;
      _powerPoints = PowerPoints;
    }
    public int GetMoveId()
    {
      return _moveId;
    }
    public string GetMoveName()
    {
      return _moveName;
    }
    public int GetBasePower()
    {
      return _basePower;
    }
    public string GetAttackStyle()
    {
      return _attackStyle;
    }
    public string GetDescription()
    {
      return _description;
    }
    public string GetSecondaryEffect()
    {
      return _secondaryEffect;
    }
    public int GetPowerPoints()
    {
      return _powerPoints;
    }

    public override bool Equals(System.Object otherMove)
    {
      if(!(otherMove is Move))
      {
        return false;
      }
      else
      {
        Move newMove = (Move) otherMove;
        bool idEquality = this.GetMoveId().Equals(newMove.GetMoveId());
        bool nameEquality = this.GetMoveName().Equals(newMove.GetMoveName());
        bool basePowerEquality = this.GetBasePower().Equals(newMove.GetBasePower());
        bool attackStyleEquality = this.GetAttackStyle().Equals(newMove.GetAttackStyle());
        bool descriptionEquality = this.GetDescription().Equals(newMove.GetDescription());
        bool secondaryEquality = this.GetSecondaryEffect().Equals(newMove.GetSecondaryEffect());
        bool powerPointsEquality = this.GetPowerPoints().Equals(newMove.GetPowerPoints());
        return (idEquality && nameEquality && basePowerEquality && attackStyleEquality && descriptionEquality && secondaryEquality && powerPointsEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetMoveId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO moves (name, basepower, attackstyle, description, secondaryeffect, powerpoints) VALUES (@moveName, @basePower, @attackStyle, @description, @secondaryEffect, @powerPoints);";

      cmd.Parameters.Add(new MySqlParameter("@moveName", _moveName));
      cmd.Parameters.Add(new MySqlParameter("@basePower", _basepower));
      cmd.Parameters.Add(new MySqlParameter("@attackStyle", _attackstyle));
      cmd.Parameters.Add(new MySqlParameter("@description", _description));
      cmd.Parameters.Add(new MySqlParameter("@secondaryEffect", _secondaryeffect));
      cmd.Parameters.Add(new MySqlParameter("@powerPoints", _powerpoints));

      cmd.ExecuteNonQuery();
      _moveId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Move> GetAllMoves()
    {
      List<Move> allMoves = new List<Move> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM moves;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int MoveId = rdr.GetInt32(0);
        string MoveName = rdr.GetString(1);
        int BasePower = rdr.GetIn32(2);
        string AttackStyle = rdr.GetString(3);
        string Description = rdr.GetString(4);
        string SecondaryEffect = rdr.GetString(5);
        int PowerPoints = rdr.GetInt32(6);
        Move newMove = new Move(MoveName, MoveId);
        allMoves.Add(newMove);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMoves;
      // return new List<Move>{};
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM moves;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static Move Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM moves WHERE id = (@searchId);";

      cmd.Parameters.Add(new MySqlParameter("@searchId", id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int MoveId = 0;
      string MoveName = "";
      int BasePower = 0;
      string AttackStyle = "";
      string Description = "";
      string SecondaryEffect = "";
      int PowerPoints = 0;

      while(rdr.Read())
      {
        MoveId = rdr.GetInt32(0);
        MoveName = rdr.GetString(1);
        BasePower = rdr.GetIn32(2);
        AttackStyle = rdr.GetString(3);
        Description = rdr.GetString(4);
        SecondaryEffect = rdr.GetString(5);
        PowerPoints = rdr.GetInt32(6);
      }
      Move newMove = new Move(MoveName, MoveId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      // return new Move("", "", 0);
      return newMove;
    }
    
    public void Edit(string newMoveName, int newBasePower, string newAttackStyle, string newDescription, string newSecondaryEffect, int newPowerPoints)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE moves SET name = @newMoveName, basepower = @newBasePower, attackStyle = @newAttackStyle, description = @newDescription, secondaryEffect = @newSecondaryEffect, powerpoints = @newPowerPoints WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _moveId));
      cmd.Parameters.Add(new MySqlParameter("@newMoveName", newMoveName));
      cmd.Parameters.Add(new MySqlParameter("@newBasePower", newBasePower));
      cmd.Parameters.Add(new MySqlParameter("@newAttackStyle", newAttackStyle));
      cmd.Parameters.Add(new MySqlParameter("@newDescription", newDescription));
      cmd.Parameters.Add(new MySqlParameter("@newSecondaryEffect", newSecondaryEffect));
      cmd.Parameters.Add(new MySqlParameter("@newPowerPoints", newPowerPoints));

      cmd.ExecuteNonQuery();
      _moveName = newMoveName;
      _basePower = newBasePower;
      _attackStyle = newAttackStyle;
      _description = newDescription;
      _secondaryEffect = newSecondaryEffect;
      _powerPoints = newPowerPoints;

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
      cmd.CommandText = @"DELETE FROM moves WHERE id = @MoveId; DELETE FROM moves_books WHERE move_id = @MoveId;";

      cmd.Parameters.Add(new MySqlParameter("@MoveId", this.GetMoveId()));

      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}
