using Microsoft.AspNetCore.Mvc;
using serverDatabaseNormalization.Models;
using Newtonsoft.Json;
using serverDatabaseNormalization.Storage;

namespace serverDatabaseNormalization.Controllers;

/// <summary>
/// Операции с пользователем
/// </summary>
public class UserController : RootController
{
    /// <summary>
    /// Проверка соединения с базой 
    /// </summary>
    /// <returns>Модели пользователей</returns>
    [HttpGet]
    public List<string?> DbContext()
    {
        Storage.DbContext db = new DbContext();
        db.connection.Open();
        List<string?> dbInfo = new List<string?>()
        {
            db.connection.ConnectionString,
            db.connection.Database,
            db.connection.DataSource,
        };
        db.connection.Close();
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
        
        // Тут лезем в БД и возвращаем всех юзеров
        
        return userModels;
    }
    
    /// <summary>
    /// Текущий пользователь
    /// </summary>
    private static UserModel _userModel = new();
    
    /// <summary>
    /// Получение всего пользователя 
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
        bool flag = true;
        
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userAuthJson.ToString() ?? string.Empty);
        /*
        здесь в базу = userModelDes?.Login;
        здесь в базу = userModelDes?.Password;
        если есть - тру и заполняем модель
        иначе фалс
        */
        return flag;
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
    /// <param name="userScoreJson">JSON-объектное представление рейтинга пользователя</param>
    /// <returns>Модель пользователя</returns>
    [HttpPost]
    public bool ChangeScore(object userScoreJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userScoreJson.ToString() ?? string.Empty);
        
        bool flag = true;
        /*

        пытаемя поменять рейтинг юзера и возвращаем буль
        */
        return flag;
    }
}