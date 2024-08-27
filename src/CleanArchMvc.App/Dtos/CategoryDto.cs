using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.App.Dtos;

public record CategoryDto
{
	public int Id { get; init; }

	[Required(ErrorMessage = "The NAME is required")]
	[MinLength(4)]
	[MaxLength(100)]
	[DisplayName("Name")]
	public string Name { get; init; } = string.Empty;
}