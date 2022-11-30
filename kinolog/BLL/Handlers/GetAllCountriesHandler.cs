using AutoMapper;
using BLL.Models;
using BLL.Queries;
using DAL.Interfaces;
using MediatR;

namespace BLL.Handlers
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public GetAllCountriesHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<CountryModel>> Handle(GetAllCountriesQuery request,
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<CountryModel>>(await _countryRepository.GetAllAsync());
        }
    }
}
