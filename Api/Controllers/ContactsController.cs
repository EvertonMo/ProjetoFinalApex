using Microsoft.AspNetCore.Mvc;
using Services.ApiServices;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ultils.Api;
using Ultils.Dtos.Contact;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService; 
        
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var result = await _contactService.GetAllAsync();

                return Ok(new ApiResponse<List<ContactResponseDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewContact([FromBody] ContactCreatRequestDto contactDto)
        {
            try
            {
                var success = await _contactService.CreateAsync(contactDto);
                if (success == true)
                {
                    return Ok(new ApiResponse());
                }
                else
                {
                    return BadRequest(new ApiResponse("User Id not found."));
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] ContactUpdateRequestDto contactDto)
        {
            try
            {
                var success = await _contactService.UpdateAsync(contactDto);

                if (success == true)
                {
                    return Ok(new ApiResponse());
                }
                else
                {
                    return BadRequest(new ApiResponse("User Id not found."));
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            try
            {
                var success = await _contactService.DeleteAsync(id);

                if (success == true)
                {
                    return Ok(new ApiResponse());
                }
                else
                {
                    return BadRequest(new ApiResponse("User Id not found."));
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }

        }
    }
}


//OK