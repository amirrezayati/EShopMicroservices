using Catalog.API.Exceptions;
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById
{
    internal class GetProductByIdQueryHandler(
        IDocumentSession _documentSession,
        ILogger<GetProductByIdQueryHandler> _logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);

            var product = await _documentSession.LoadAsync<Product>(query.Id ,cancellationToken);
            return product is null ? throw new ProductNotFoundException() : new GetProductByIdResult(product);
        }
    }

    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
}
