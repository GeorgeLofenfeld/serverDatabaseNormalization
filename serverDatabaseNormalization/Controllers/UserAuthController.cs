using Microsoft.AspNetCore.Mvc;
using serverDatabaseNormalization.Models;
using Newtonsoft.Json;

namespace serverDatabaseNormalization.Controllers;

public class UserAuthController : RootController
{
    private static UserModel _userModel = new();
    
    [HttpGet]
    public string? OutputLogin()
    {
        return _userModel.Login;
    }

    [HttpPost]
    public UserModel Auth(object userModelJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userModelJson.ToString() ?? string.Empty);

        _userModel.Login = userModelDes?.Login;
        _userModel.Password = userModelDes?.Password;
        
        return _userModel;
    }
    
    [HttpPost]
    public UserModel Regist(object userModelJson)
    {
        UserModel? userModelDes = JsonConvert.DeserializeObject<UserModel>(userModelJson.ToString() ?? string.Empty);

        _userModel.Login = userModelDes?.Login;
        _userModel.Password = userModelDes?.Password;
        
        return _userModel;
    }
}