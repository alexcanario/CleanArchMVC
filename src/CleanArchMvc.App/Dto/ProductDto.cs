﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.App.Dto;

public record ProductDto(int Id, string Name, decimal Price, int Stock, string Image)
{
	public int Id { get; init; }

	[Required(ErrorMessage = "The NAME is required")]
	[MinLength(3)]
	[MaxLength(100)]
	[DisplayName("Name")]
	public string Name { get; init; } = string.Empty;

	[Required(ErrorMessage = "The DESCRIPTION is required")]
	[MinLength(5)]
	[MaxLength(200)]
	[DisplayName("Description")]
	public string Description { get; init; } = string.Empty;

	[Required(ErrorMessage = "The PRICE is required")]
	[Column(TypeName = "decimal(18,2")]
	[DisplayFormat(DataFormatString = "{0:C2}")]
	[DataType(dataType:DataType.Currency)]
	[DisplayName("Price")]
	public decimal Price { get; init; }

	[Required(ErrorMessage = "The STOCK is required")]
	[Range(1, 9999)]
	[DisplayName("Stock")]
	public int Stock { get; init; }

	[MaxLength(250)]
	[DisplayName("ProductDto Image")]
	public string Image { get; init; } = string.Empty;

	[DisplayName("CategoryDto")]
	public int CategoryId { get; init; }
	public CategoryDto? Category { get; init; }
}