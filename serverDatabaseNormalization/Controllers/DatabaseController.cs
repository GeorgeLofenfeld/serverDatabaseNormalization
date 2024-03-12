using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using serverDatabaseNormalization.Models;
using serverDatabaseNormalization.Storage;

namespace serverDatabaseNormalization.Controllers;

public class DatabaseController : RootController
{
    readonly DbContext _db = new DbContext();
    
    /// <summary>
    /// Проверка соединения с базой 
    /// </summary>
    /// <returns>Список параметров базы</returns>
    [HttpGet]
    public List<string?> Context()
    {
        _db.connection.Open();
        
        List<string?> dbInfo = new List<string?>
        {
            _db.connection.ConnectionString,
            _db.connection.Database,
        };
        
        _db.connection.Close();
        
        return dbInfo;
    }
    
    /// <summary>
    /// Получение всех пользователей 
    /// </summary>
    /// <returns>Модели пользователей</returns>
    [HttpGet]
    public List<UserModel>? Users()
    {
        List<UserModel> userModels = new List<UserModel>();
        
        _db.connection.Open();
        
        SqlCommand command = new SqlCommand("SELECT * FROM Users", _db.connection);
        SqlDataReader reader = command.ExecuteReader();
        
        if (!reader.HasRows) return userModels;
        
        while (reader.Read())
        {
            userModels.Add(new UserModel()
            {
                Login = reader["login"].ToString(),
                Score = (int)reader["score"],
            });
        }

        _db.connection.Close();
        
        return userModels;
    }
    
    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public bool DeleteUser(object userLoginJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userLoginJson.ToString() ?? string.Empty);
        
        _db.connection.Open();
        
        SqlCommand command = new SqlCommand($"DELETE FROM Users WHERE login = '{userModelDes.Login}'", _db.connection);
        SqlDataReader reader = command.ExecuteReader();
        
        _db.connection.Close();
        
        return true;
    }
}