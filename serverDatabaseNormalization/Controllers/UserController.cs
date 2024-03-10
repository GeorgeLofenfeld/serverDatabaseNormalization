using Microsoft.AspNetCore.Mvc;
using serverDatabaseNormalization.Models;
using Newtonsoft.Json;

namespace serverDatabaseNormalization.Controllers;

public class UserController : RootController
{
    private static UserModel _userModel = new();
    
    /// <summary>
    /// Получение всего пользователя 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public new UserModel? User()
    {
        return _userModel;
    }
    
    /// <summary>
    /// Получение логина 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public string? Login()
    {
        return _userModel.Login;
    }
    
    /// <summary>
    /// Получение рейтинга
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public int Score()
    {
        return _userModel.CurrentScore;
    }

    /// <summary>
    /// Авторизация
    /// </summary>
    /// <param name="userModelJson"></param>
    /// <returns></returns>
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
    /// <param name="userModelJson"></param>
    /// <returns></returns>
    [HttpPost]
    public UserModel Registr(object userModelJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userModelJson.ToString() ?? string.Empty);

        _userModel.Id = Guid.NewGuid();
        _userModel.Login = userModelDes?.Login;
        _userModel.Password = userModelDes?.Password;
        _userModel.Gender = userModelDes?.Gender;
        
        return _userModel;
    }
}