using System.ComponentModel.DataAnnotations.Schema;

namespace serverDatabaseNormalization.Models;

/// <summary>
/// Пользователь
/// </summary>
public class UserModel
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    internal Guid Id { get; set; }
    
    /// <summary>
    /// Логин
    /// </summary>
    public string? Login { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string? Password { get; set; }
    
    /// <summary>
    /// Пол пользователя
    /// </summary>
    public string? Gender { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Количество очков
    /// </summary>
    public int Score { get; set; } = 0;
}