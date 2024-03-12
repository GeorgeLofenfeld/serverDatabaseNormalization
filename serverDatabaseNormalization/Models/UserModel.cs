using System.ComponentModel.DataAnnotations.Schema;

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
    /// Количество очков
    /// </summary>
    public int Score { get; set; } = 0;
}