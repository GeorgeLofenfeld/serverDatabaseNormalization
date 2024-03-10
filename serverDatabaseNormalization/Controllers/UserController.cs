using Microsoft.AspNetCore.Mvc;
using serverDatabaseNormalization.Models;
using Newtonsoft.Json;

namespace serverDatabaseNormalization.Controllers;

public class UserController : RootController
{
    private static UserModel _userModel = new();
    
    /// <summary>
    /// Получение логина 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public string? OutputLogin()
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
        
        return _userModel;
    }
    
    /// <summary>
    /// Регистрация
    /// </summary>
    /// <param name="userModelJson"></param>
    /// <returns></returns>
    [HttpPost]
    public UserModel Regist(object userModelJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userModelJson.ToString() ?? string.Empty);

        _userModel.Login = userModelDes?.Login;
        _userModel.Password = userModelDes?.Password;
        
        return _userModel;
    }
}