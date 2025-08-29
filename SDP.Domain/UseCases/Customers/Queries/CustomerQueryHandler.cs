using AutoMapper;
using SDP.Domain.Dtos;
using SDP.Domain.Repository;

namespace SDP.Domain.UseCases.Customers.Queries
{
    public class CustomerQueryHandler : ICustomerQueryHandler
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll(cancellationToken);
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByID(id, cancellationToken);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
