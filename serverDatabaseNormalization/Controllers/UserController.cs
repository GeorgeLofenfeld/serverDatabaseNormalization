using Microsoft.AspNetCore.Mvc;
using serverDatabaseNormalization.Models;
using Newtonsoft.Json;

namespace serverDatabaseNormalization.Controllers;

/// <summary>
/// Операции с пользователем
/// </summary>
public class UserController : RootController
{
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
    /// Получение рейтинга
    /// </summary>
    /// <returns>Рейтинг пользователя</returns>
    [HttpGet]
    public int? ScoreGet()
    {
        return _userModel.CurrentScore;
    }
    
    /// <summary>
    /// Успешность авторизации или регистрации
    /// </summary>
    /// <returns>Флаг успешности</returns>
    [HttpGet]
    public bool Succsess()
    {
        bool flag = true;

        if (flag)
        {
            return true;
        }
        
        return false;
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
        
        return _userModel;
    }

    /// <summary>
    /// Изменение количества очков пользователя
    /// </summary>
    /// <param name="scoreJson">JSON-объектное представление количества очков пользователя</param>
    /// <returns>Новое количетсов очков пользователя</returns>
    [HttpPost]
    public int? ScorePost(object scoreJson)
    {
        UserModel? scoreDes = JsonConvert.DeserializeObject<UserModel>(scoreJson.ToString() ?? string.Empty);

        _userModel.CurrentScore = scoreDes?.CurrentScore;
        
        return _userModel.CurrentScore;
    }
}