namespace serverDatabaseNormalization.Models;

/// <summary>
/// Пользователь
/// </summary>
public class UserModel
{
    public Guid Id { get; set; }
    
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
    
    /// <summary>
    /// Пол пользователя
    /// </summary>
    public string? Gender { get; set; }
    
    public bool? Remember { get; set; }
}