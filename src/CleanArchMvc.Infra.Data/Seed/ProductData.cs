using CleanArchMvc.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Seed;

public static class ProductData
{
    public static void Sow(ModelBuilder builder)
    {
        var productsGroup1List = new List<Product>
        {
            new (1, "Papel", "Papel A4", 10M, 1, string.Empty, 1),
            new (2, "Caneta", "Caneta bic", 2M, 10, string.Empty, 1),
            new (3, "Lápis", "Lápis Faber Castel", 4M, 10, string.Empty, 1),
            new (4, "Celular", "Celular A12", 1200M, 10, string.Empty, 2),
            new (5, "Tv Smart", "Tv 32 polegadas Samsung", 2500M, 10, string.Empty, 2),
            new (6, "Notebook", "Notebook Avell liv62", 9870M, 10, string.Empty, 2),
            new (7, "Bolsa", "Bolsa de couro legítimo", 500M, 1, string.Empty, 3),
            new (8, "Necessary", "Necessary padrão", 150M, 10, string.Empty, 3),
            new (9, "Pasta", "Pasta térmica", 22M, 10, string.Empty, 3)
        };

        builder.Entity<Product>().HasData(productsGroup1List);
    }
}