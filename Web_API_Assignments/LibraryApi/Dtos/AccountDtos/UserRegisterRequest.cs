using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos.AccountDtos;

public class UserRegisterRequest
{
    [Required, EmailAddress, MaxLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
