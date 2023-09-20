using Application.IServices;
using AutoMapper;
using Common;
using Common.Repository;
using Model;

namespace Application;

public class ProductService : IProductService
{
    private readonly OnPanelAppContext _appContext;
    private readonly IRepositoryBase<Product> _repositoryBase;
    private readonly IMapper _mapper;
    public ProductService(
        OnPanelAppContext appContext, 
        IRepositoryBase<Product> repositoryBase,
        IMapper mapper)
    {
        _appContext = appContext;
        _repositoryBase = repositoryBase;
        _mapper = mapper;
    }

    public bool DeleteProduct(int id)
    {
        _repositoryBase.Delete(id);
        return true;
    }

    public List<ProductDto> GetAllProducts()
    {
        IEnumerable<Product> entities = _repositoryBase
            .GetAll()
            .Where(x => x.UserId == _appContext.UserId)
            .ToList();

        return _mapper.Map<List<ProductDto>>(entities);
    }

    public ProductDto GetProductById(int id)
    {
        Product? entity = _repositoryBase.GetById(id);

        if(entity == null)
        {
            throw new Exception("Producto no encontrado");
        } else
        {
            return _mapper.Map<ProductDto>(entity);
        }
    }

    public bool UpdateProduct(ProductDto product)
    {
        Product productToUpdate = _mapper.Map<Product>(product);
        productToUpdate.UserId = (int)_appContext.UserId;

        _repositoryBase.Update(productToUpdate);

        return true;
    }
}
