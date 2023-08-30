using InitMediaContentService.Domain.Interfaces;
using MediatR;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Exceptions;
using Microsoft.Extensions.Logging;
using InitMediaContentService.Domain.Entities;

namespace InitMediaContentService.Application.Handlers
{
    public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, ArtistDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ArtistMapper _artistMapper;
        private readonly ILogger _logger;

        public GetArtistByIdQueryHandler(ILogger<Artist> logger, IUnitOfWork unitOfWork, ArtistMapper artistMapper)
        {
            _unitOfWork = unitOfWork;
            _artistMapper = artistMapper;
            _logger = logger;
        }
        public async Task<ArtistDto> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting Artist with id = {request.id}");

            var artist = await _unitOfWork.ArtistRepository.FindByIdAsync(request.id, cancellationToken);

            if (artist == null)
            {
                _logger.LogError($"In GetArtistById Artist with id = {request.id} not found");
                throw new ArtistNotFoundException($"Artist with id = {request.id} not found");
            }

            _logger.LogInformation($"Artist with id = {request.id} found");

            return _artistMapper.ArtistToArtistDto(artist);
        }
    }
}
