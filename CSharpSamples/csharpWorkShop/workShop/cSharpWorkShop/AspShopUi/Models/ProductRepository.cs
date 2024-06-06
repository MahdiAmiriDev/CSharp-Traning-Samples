namespace AspShopUi.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;
        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PageData<Product> GetAll(int pageNumber, int pageSize)
        {
            var result = new PageData<Product>
            {
                PageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                }
            };

            result.Data = _dbContext.Products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount = _dbContext.Products.Count();
            return result;
        }
    }
}
