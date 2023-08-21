using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models;

public abstract class BaseModel
{
    [Key, Column("id")]
    public Guid Id { get; set; }
}