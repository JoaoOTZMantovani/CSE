using Microsoft.AspNetCore.Mvc;

namespace CSE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    public ActionResult<ProductsResponse> Get()
    {
        return Ok(new ProductsResponse
        {
            Ok = true,
            Message = "Products retrieved successfully.",
            Products = new List<Product>
            {
                new Product
                {
                    Id = Guid.Parse("177c382b-9211-4f8d-a726-a9386197c558"),
                    Name = "Banho de Ervas",
                    MaterialValue = 2.35m,
                    ProductionValue = 0.50m,
                    ProfitValue = 1.00m
                },
                new Product
                {
                    Id = Guid.Parse("4e0d8ac9-e17c-4c0c-a4a2-25ae8b0cc584"),
                    Name = "Banho de Ervas Premium",
                    MaterialValue = 6.85m,
                    ProductionValue = 1.40m,
                    ProfitValue = 2.80m
                },
                new Product
                {
                    Id = Guid.Parse("8d0a5c19-3f47-4e5a-b87f-63cfbbbdbf24"),
                    Name = "Frasco de Alfazema Rustico",
                    MaterialValue = 13.90m,
                    ProductionValue = 2.80m,
                    ProfitValue = 5.60m
                }
            }
        });
    }
}