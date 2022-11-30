using AutoMapper;
using BLL.Commands;
using BLL.Exceptions;
using DAL.Interfaces;
using MediatR;

namespace BLL.Handlers
{
    public class DeleteCountryHandler : AsyncRequestHandler<DeleteCountryCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public DeleteCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        protected override async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _countryRepository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(request.Id);

            await _countryRepository.DeleteByIdAsync(request.Id);
            await _countryRepository.SaveChangesAsync();
        }
    }
}
