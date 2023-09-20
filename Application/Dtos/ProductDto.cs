using System.ComponentModel.DataAnnotations;

namespace Application;

public class ProductDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo 'Nombre' es necesario")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo 'Descripcion' es necesario")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo 'Precio' es necesario")]
    public double Price { get; set; }

    [Required(ErrorMessage = "El campo 'Stock' es necesario")]
    public int Stock { get; set; }

    public string? ImageUrl { get; set; } = string.Empty;
}
