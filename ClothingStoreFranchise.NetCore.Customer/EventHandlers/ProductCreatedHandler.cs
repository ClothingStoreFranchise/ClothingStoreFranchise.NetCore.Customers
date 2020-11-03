using AutoMapper;
using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Customers.Dao;
using ClothingStoreFranchise.NetCore.Customers.Dto.Events;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Customers.EventHandlers
{
    public class ProductCreatedHandler : IIntegrationEventHandler<CreateProductEvent>
    {
        private readonly IProductDao _productDao;
        private readonly IMapper _mapper;

        public ProductCreatedHandler(IProductDao productDao, IMapper mapper)
        {
            _productDao = productDao;
            _mapper = mapper;
        }

        public async Task HandleAsync(CreateProductEvent @event)
        {
            //var customer = new CreateProductEvent(@event.Id, @event.Stock, @event.UnitPrice, @event.PictureUrl);
            
            decimal a = @event.Stock;
            string b = @event.PictureUrl;
            long c = @event.Id;
            /*var customer = _mapper.Map<Product>(@event);
            await _productDao.CreateAsync(customer);*/
        }
    }
}
