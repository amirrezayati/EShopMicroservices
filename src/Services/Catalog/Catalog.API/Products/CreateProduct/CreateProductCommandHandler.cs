using BuildingBlocks.CQRS;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Business logic to create a product
            throw new NotImplementedException();
        }
    }

    public record CreateProductCommand(string Name, string Description, string ImageFile, decimal Price, List<string> Categories) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
}
