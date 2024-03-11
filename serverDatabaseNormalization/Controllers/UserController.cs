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
    private DbContext db = new DbContext();
    
    /// <summary>
    /// Пользователь
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
    /// Получение логина 
    /// </summary>
    /// <returns>Логин пользователя</returns>
    [HttpGet]
    public string? Login()
    {
        return _userModel.Login;
    }

    /// <summary>
    /// Авторизация
    /// </summary>
    /// <param name="userModelJson">JSON-объектное представление модели пользователя</param>
    /// <returns>Модель пользователя</returns>
    [HttpPost]
    public UserModel Auth(object userModelJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userModelJson.ToString() ?? string.Empty);

        _userModel.Login = userModelDes?.Login;
        _userModel.Password = userModelDes?.Password;
        _userModel.Remember = userModelDes?.Remember;
        
        return _userModel;
    }

    /// <summary>
    /// Регистрация
    /// </summary>
    /// <param name="userModelJson">JSON-объектное представление модели пользователя</param>
    /// <returns>Модель пользователя</returns>
    [HttpPost]
    public UserModel Registr(object userModelJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userModelJson.ToString() ?? string.Empty);

        _userModel.Id = Guid.NewGuid();
        _userModel.Login = userModelDes?.Login;
        _userModel.Password = userModelDes?.Password;
        _userModel.Gender = userModelDes?.Gender;
        _userModel.Date = userModelDes?.Date;

        db.Users.Add(_userModel);
        db.SaveChanges();
        
        return _userModel;
    }
}