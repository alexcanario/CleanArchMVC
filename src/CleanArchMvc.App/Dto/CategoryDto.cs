using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.App.Dto;

public record CategoryDto
{
	public int Id { get; init; }

	[Required(ErrorMessage = "The NAME is required")]
	[MinLength(3)]
	[MaxLength(100)]
	[DisplayName("Name")]
	public string Name { get; init; } = string.Empty;
}