using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProducts
{
    internal class GetProductsQueryHandler(
        IDocumentSession _documentSession,
        ILogger<GetProductsQueryHandler> _logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

            var products = await _documentSession.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(products);
        }
    }

    public record GetProductsQuery : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
}
