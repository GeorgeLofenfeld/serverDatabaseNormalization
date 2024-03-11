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
    /// Флаг запоминания входа
    /// </summary>
    public bool? Remember { get; set; }
    
    /// <summary>
    /// Количество набранных баллов за последнюю попытку
    /// </summary>
    public int? CurrentScore { get; set; }
}