using DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [ResponseCache(Duration =10)] //gelen parametreyi 10 saniye cache'de tutar
        [HttpGet("{id}")]
        public async Task<ContactDVO> GetContactById(int id)
        {
            return await _contactService.GetContactById(id);
        }
        [HttpGet]
        public ContactDVO CreateContact(ContactDVO contactDVO)
        {
            return contactDVO;
        }
    }
}
