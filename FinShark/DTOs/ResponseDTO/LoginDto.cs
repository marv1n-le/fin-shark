using System.ComponentModel.DataAnnotations;

namespace FinShark.DTOs.ResponseDTO;

public class LoginDto
{
    [Required]
    public string Username { get; set; } 
    [Required]
    public string Password { get; set; }
}