using AutoMapper;
using BLL.Commands;
using BLL.Models;
using DAL.Data;
using DAL.Interfaces;
using DAL.Repositories;
using MediatR;

namespace BLL.Handlers
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, CountryModel>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public UpdateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<CountryModel> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.Country);

            var entity = await _countryRepository.GetByIdAsync(request.Country.Id);
            _countryRepository.Update(entity);
            await _countryRepository.SaveChangesAsync();
            return request.Country;
        }
    }
}
