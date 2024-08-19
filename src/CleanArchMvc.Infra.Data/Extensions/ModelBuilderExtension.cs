using CleanArchMvc.Infra.Data.Seed;

using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Extensions;

public static class ModelBuilderExtension
{
    public static void Sow(this ModelBuilder builder)
    {
        ProductData.Sow(builder);
    }
}