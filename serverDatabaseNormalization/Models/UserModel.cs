using System.ComponentModel.DataAnnotations.Schema;

namespace serverDatabaseNormalization.Models;

/// <summary>
/// Пользователь
/// </summary>
[Table("Users", Schema = "adm")]
public class UserModel
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Column("ID")]
    internal Guid Id { get; set; }
    
    /// <summary>
    /// Логин
    /// </summary>
    [Column("Login")]
    public string? Login { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [Column("Password")]
    public string? Password { get; set; }
    
    /// <summary>
    /// Пол пользователя
    /// </summary>
    [Column("Gender")]
    public string? Gender { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    [Column("Date")]
    public DateTime? Date { get; set; }
    
    /// <summary>
    /// Флаг запоминания входа
    /// </summary>
    public bool? Remember { get; set; }
}