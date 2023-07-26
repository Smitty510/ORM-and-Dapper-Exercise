using Dapper;
using System.Data;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }
        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductId = @id;", new { id });
        }
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products " +
                "SET Name = @name, " +
                "Price = @price, " +
                "CategoryId = @catID, " +
                "OnSale = @onSale, " +
                "StockLevel = @stock" +
                "WHERE ProductID = @id;",
                new
                {
                    name = product.Name,
                    price = product.Price,
                    catID = product.CategoryID,
                    onSale = product.OnSale,
                    stock = product.StockLevel
                });
        }

        IEnumerable<Product> IProductRepository.GetAllProducts()
        {
            throw new NotImplementedException();
        }

        Product IProductRepository.GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        void IProductRepository.UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
