using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using serverDatabaseNormalization.Models;
using Newtonsoft.Json;
using serverDatabaseNormalization.Storage;

namespace serverDatabaseNormalization.Controllers;

/// <summary>
/// Операции с пользователями
/// </summary>
public class UserController : RootController
{
    /// <summary>
    /// База данных
    /// </summary>
    readonly DbContext _db = new DbContext();
    
    /// <summary>
    /// Текущий пользователь
    /// </summary>
    private static UserModel _userModel = new();
    
    /// <summary>
    /// Получение всего текущего пользователя 
    /// </summary>
    /// <returns>Модель пользователя</returns>
    [HttpGet]
    public new UserModel? User()
    {
        return _userModel;
    }
    
    /// <summary>
    /// Получение логина текущего пользователя
    /// </summary>
    /// <returns>Логин пользователя</returns>
    [HttpGet]
    public string? Login()
    {
        return _userModel.Login;
    }
    
    /// <summary>
    /// Получение рейтинга текущего пользователя
    /// </summary>
    /// <returns>Рейтинг пользователя</returns>
    [HttpGet]
    public int Score()
    {
        return _userModel.Score;
    }

    /// <summary>
    /// Авторизация
    /// </summary>
    /// <param name="userAuthJson">JSON-объектное представление авторизации пользователя</param>
    /// <returns>Модель пользователя</returns>
    [HttpPost]
    public bool Auth(object userAuthJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userAuthJson.ToString() ?? string.Empty);
        
        _db.connection.Open();
        
        SqlCommand command = new SqlCommand("SELECT ID, login, dateOfBirth, gender, score, password FROM Users", _db.connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            
            if ((reader["login"].ToString() != userModelDes?.Login) ||
                (reader["password"].ToString() != userModelDes?.Password)) continue;
            
            _userModel.Id = (Guid)reader["ID"];
            _userModel.Login = reader["login"].ToString();
            _userModel.Password = reader["password"].ToString();
            _userModel.Date = (DateTime)reader["dateOfBirth"];
            _userModel.Gender = reader["gender"].ToString();
            _userModel.Score = (int)reader["score"];
                
            _db.connection.Close();
            return true;
        }
        _db.connection.Close();
        return false;
    }

    /// <summary>
    /// Регистрация
    /// </summary>
    /// <param name="userRegistrJson">JSON-объектное представление регистрации пользователя</param>
    /// <returns>Модель пользователя</returns>
    [HttpPost]
    public bool Registr(object userRegistrJson)
    {
        bool flag = true;
        
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userRegistrJson.ToString() ?? string.Empty);
        
        /*
        
        проверяю есть ли в бд такой  логин = userModelDes?.Login;
        если есть - false
        иначе заполняем
        = userModelDes?.Login
        = userModelDes?.Password;
        = userModelDes?.Gender;
        = userModelDes?.Date;
        */
        
        return flag;
    }
    
    /// <summary>
    /// Изменение рейтинга
    /// </summary>
    /// <param name="userModelJson">JSON-объектное представление ID пользователя</param>
    /// <returns>Модель пользователя</returns>
    [HttpPost]
    public bool ChangeScore(object userScoreJson)
    {
        bool flag = false;
        
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userScoreJson.ToString() ?? string.Empty);
        
        _db.connection.Open();
        
        SqlCommand command = new SqlCommand("SELECT login FROM Users", _db.connection);
        SqlDataReader reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            if (reader["login"].ToString() != userModelDes?.Login) continue;
            
            flag = true;
            
            break;
        }
        
        _db.connection.Close();

        if (!flag) return false;
        
        _db.connection.Open();
            
        SqlCommand commandUpdate = new SqlCommand(
            $"UPDATE Users SET score = {userModelDes.Score} WHERE login = '{userModelDes.Login}'", _db.connection);
        commandUpdate.ExecuteNonQuery();
            
        _db.connection.Close();

        return true;

    }
}