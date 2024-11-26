using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new()
            {
                Name = request.Name,
                Category = request.Category,
                Description = request.Description,
                Id = Guid.NewGuid(),
                ImageFile = request.ImageFile,
                Price = request.Price
            };
            return new CreateProductResult(product.Id);
        }
    }

    public record CreateProductCommand(string Name, string Description, string ImageFile, decimal Price, List<string> Category) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
}
