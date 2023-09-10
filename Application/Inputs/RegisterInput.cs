using System.ComponentModel.DataAnnotations;

namespace Application;

public class RegisterInput
{
    [Required(ErrorMessage = "El campo Email es requerido")]
    [EmailAddress(ErrorMessage = "Debe introducir un email válido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "El campo Contraseña es requerido")]
    public string Password { get; set; }
    [Required(ErrorMessage = "El campo Confirmar Contraseña es requerido")]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = "El campo Nombre es requerido")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "El campo Apellido es requerido")]
    public string LastName { get; set; }
}
