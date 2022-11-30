using AutoMapper;
using BLL.Commands;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using MediatR;

namespace BLL.Handlers
{
    public class AddCountryHandler : IRequestHandler<AddCountryCommand, CountryModel>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public AddCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<CountryModel> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.Country);
            var entity = _mapper.Map<Country>(request.Country);

            await _countryRepository.AddAsync(entity);
            await _countryRepository.SaveChangesAsync();
            return request.Country;
        }
    }
}
