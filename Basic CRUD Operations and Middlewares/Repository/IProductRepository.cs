using Basic_CRUD_Operations_and_Middlewares.Models;

namespace Basic_CRUD_Operations_and_Middlewares.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
