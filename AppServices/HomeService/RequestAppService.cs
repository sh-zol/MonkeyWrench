using Domain.Core.HomeService.Contracts.AppServices;
using Domain.Core.HomeService.Contracts.Services;
using Domain.Core.HomeService.DTOS;
using Domain.Core.User.Contracts.AppServices;
using Domain.Core.User.Contracts.Services;
using Domain.Core.User.DTOs;
using Domain.Core.User.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.HomeService
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _service;
        private readonly IPersonService _person;
        private readonly IAppUserAppService _appuser;

        public RequestAppService(IRequestService service,IPersonService personService,IAppUserAppService appUserAppService)
        {
            _service = service;
            _person = personService;
            _appuser = appUserAppService;
        }

        public async Task Create(RequestDTO requestDTO,IFormFile file,CancellationToken cancellationToken)
        {
            if (file is not null)
            {
                var ImageAddress = await _person.UploadFilePic(file, cancellationToken);
                requestDTO.FileLocation = ImageAddress;
            }
            await _service.Create(requestDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        public async Task<List<RequestDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetAllByCustomerId(int customerId, CancellationToken cancellationToken)
        {
            return await _service.GetAllByCustomerId(customerId, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetAllByExpertId(CancellationToken cancellationToken)
        {
            var expertid = await _appuser.LoggedInUserId();
            var result = await _person.GetExpert(expertid, cancellationToken);
            var requests = await _service.GetAllByExpertId(result, cancellationToken);
            return requests;
        }

        public async Task<List<RequestDTO>?> GetAllByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await _service.GetAllByRequestId(requestId, cancellationToken);
        }

        public async Task<List<RequestDTO>?> GetAllExpertRequests(CancellationToken cancellationToken)
        {
            var expertId = await _appuser.LoggedInUserId();
            var result = await _person.GetExpert(expertId, cancellationToken);
            var requests = await _service.GetAllExpertRequests(result, cancellationToken);
            return requests;
        }

        public async Task<List<RequestDTO>?> GetAllProcceingRequests(CancellationToken cancellationToken)
        {
            var expertId = await _appuser.LoggedInUserId();
            var result = await _person.GetExpert(expertId, cancellationToken);
            var requests = await _service.GetAllProcceingRequests(result, cancellationToken);
            return requests;
        }

        public async Task<RequestDTO>? GetByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await _service.GetByRequestId(requestId, cancellationToken);
        }

        public async Task Update(RequestDTO requestDTO, CancellationToken cancellationToken)
        {
            await _service.Update(requestDTO, cancellationToken);
        }
    }
}
