using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Exceptions;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Domain.Entities;
using InitMediaContentService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InitMediaContentService.Application.Handlers
{
    public class GetReleaseByIdQueryHandler : IRequestHandler<GetReleaseByIdQuery, ReleaseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ReleaseMapper _releaseMapper;
        private readonly ILogger _logger;

        public GetReleaseByIdQueryHandler(ILogger<Release> logger, IUnitOfWork unitOfWork, ReleaseMapper releaseMapper)
        {
            _unitOfWork = unitOfWork;
            _releaseMapper = releaseMapper;
            _logger = logger;
        }
        public async Task<ReleaseDto> Handle(GetReleaseByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting Release with id = {request.id}");

            var release = await _unitOfWork.ReleaseRepository.FindByIdAsync(request.id, cancellationToken);

            if (release == null)
            {
                _logger.LogError($"In GetReleaseById Release with id = {request.id} not found");
                throw new ReleaseNotFoundException($"Release with id = {request.id} not found");
            }

            _logger.LogInformation($"Release with id = {request.id} found");

            return _releaseMapper.ReleaseToReleaseDto(release);
        }
    }
}
