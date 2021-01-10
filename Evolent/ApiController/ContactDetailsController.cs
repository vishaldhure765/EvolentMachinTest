using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Evolent.Domain.DataModel;
using Evolent.Service.ContactInformation;
using Evolent.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evolent.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly IContactInfoService contactInfoService;
        private readonly IMapper mapper;

        public ContactDetailsController(IContactInfoService _contactInfoService,IMapper _mapper)
        {
            this.contactInfoService = _contactInfoService;
            this.mapper = _mapper;
        }
        // GET: api/ContactDetails
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<ContactInfoViewModel> list = null;
            try
            {
                list = mapper.Map<List<ContactInfo>,List<ContactInfoViewModel>>(await contactInfoService.GetContactInfoList());
            }
            catch (Exception ex)
            {
                ex.ToString();
                return NotFound();
            }
            return Ok(list);
        }

        //// GET: api/ContactDetails/5
        //[HttpGet("{id}", Name = "Delete")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET: api/ContactDetails/5
        [HttpGet("{id}", Name = "Delete")]
        public async Task<ActionResult> Get(int id)
        {
            long result = 0;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                else
                {
                    result = await contactInfoService.DeleteContactInfo(id);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return Ok(result);
        }

        //// POST: api/ContactDetails
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactInfoViewModel info)
        {
            int result = 0;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                else
                {
                   await contactInfoService.AddOrUpdateContactInfo(mapper.Map<ContactInfoViewModel,ContactInfo>(info));
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return Ok(result);
        }

        // PUT: api/ContactDetails/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
