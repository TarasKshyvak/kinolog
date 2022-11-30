using AutoMapper;
using BLL.Exceptions;
using BLL.Models;
using BLL.Queries;
using DAL.Data;
using DAL.Interfaces;
using DAL.Repositories;
using MediatR;

namespace BLL.Handlers
{
    public class GetByIdCountryHandler : IRequestHandler<GetByIdCountryQuery, CountryModel>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public GetByIdCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }
        public async Task<CountryModel> Handle(GetByIdCountryQuery request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetByIdAsync(request.Id);

            if (country == null)
                throw new NotFoundException(request.Id);

            return _mapper.Map<CountryModel>(country);
        }
    }
}
