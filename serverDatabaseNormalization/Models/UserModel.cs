namespace serverDatabaseNormalization.Models;

/// <summary>
/// Пользователь
/// </summary>
public class UserModel
{
    /// <summary>
    /// Логин
    /// </summary>
    public string? Login { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string? Password { get; set; }
    
    /// <summary>
    /// Количество набранных баллов за последнюю попытку
    /// </summary>
    public int CurrentScore { get; set; }
}