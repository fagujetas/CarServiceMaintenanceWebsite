using System.Collections.Generic;
using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/dealer")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly IDealerRepo _dealerRepo;
        private readonly IMapper _mapper;
        public DealerController(IDealerRepo dealerRepo, IMapper mapper)
        {
            _dealerRepo = dealerRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DealerReadDto>> GetAllDealers()
        {
            var dealerItems = _dealerRepo.GetAllDealers();
            return Ok(_mapper.Map<IEnumerable<DealerReadDto>>(dealerItems));
        }

        [HttpGet("{id}", Name = "GetDealerById")]
        public ActionResult<DealerReadDto> GetDealerById(int id)
        {

            var dealerItem = _dealerRepo.GetDealerInfoById(id);

            if (dealerItem != null)
            {
                return Ok(_mapper.Map<DealerReadDto>(dealerItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<DealerReadDto> CreateDealerInfo(DealerCreateDto dealerCreateDto)
        {
            var dealer = _mapper.Map<DealerInfo>(dealerCreateDto);

            _dealerRepo.CreateDealerInfo(dealer);
            _dealerRepo.SaveChanges();

            //placeholder to map this into the DTO
            var dealerReadDto = _mapper.Map<DealerReadDto>(dealer);

            //NB: Creates a CreatedAtRouteResult object that produces a Microsoft.AspNetCore.Http.StatusCodes.Status201Created response
            return CreatedAtRoute(nameof(CreateDealerInfo), new { Id = dealerReadDto.Id }, dealerReadDto);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCoreMVC(int id, DealerUpdateDto coreMVCUpdateDto)
        {
            var dealerFromRepo = _dealerRepo.GetDealerInfoById(id);

            if (dealerFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(coreMVCUpdateDto, dealerFromRepo); // *1

            //note that we do not have implementation in our sql repository,
            //this mapping exercise here has basically done is its actually updated
            //coreMVCModelFromRepo and changes are actually being tracked via dbcontext,
            //we dont actually need to do anything else w/ it other than save changes (need to flush it down to our db)
            //in interest of maintaining separate interface from implementation,
            //good practice is still to call update method on our repository and supply in our model from repo
            //because other implementations may require us to to that
            //even though it is counterintuitive
            _dealerRepo.UpdateDealerInfo(dealerFromRepo);

            //flush down changes to the db that were made at (*1)
            _dealerRepo.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult PartialCoreMVCUpdate(int id, JsonPatchDocument<DealerUpdateDto> patchDoc)
        {
            var dealerFromRepo = _dealerRepo.GetDealerInfoById(id);

            if (dealerFromRepo == null)
            {
                return NotFound();
            }

            //since we are receiving from our client a JsonPatchDocument
            //that we want to apply to our model
            //but we cannot apply it directly to model since this is an updatedto patch document
            //and the other is model, so what we need to do (in order to apply the patch)
            //is create a new update dto; 
            //so its creating a new update dto with the contents from our repository 
            //and putting it in coreMvcPatch
            var dealerToPatch = _mapper.Map<DealerUpdateDto>(dealerFromRepo);

            //NB @ ModelState: makes sure that validations are valid
            patchDoc.ApplyTo(dealerToPatch, ModelState);

            if (!TryValidateModel(dealerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(dealerToPatch, dealerFromRepo);
            _dealerRepo.UpdateDealerInfo(dealerFromRepo);
            _dealerRepo.SaveChanges();

            return NoContent();
        }
    }
}