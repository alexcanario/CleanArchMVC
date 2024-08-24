namespace CleanArchMvc.App.Products.Commands;

public class ProductUpdateCommand(int id) : ProductCommand
{
    public int Id { get; set; } = id;
}