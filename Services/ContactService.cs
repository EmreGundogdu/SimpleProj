using AutoMapper;
using DataModels;
using Models;

namespace Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory httpClientFactory;
        public ContactService(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ContactDVO> GetContactById(int id)
        {
            Contact contact = GetDummyContact();
            return _mapper.Map<ContactDVO>(contact);
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("garanti.com");
            //client.DefaultRequestHeaders.Add("Authorization", "Bearer 12121212");
            //string get = await client.GetStringAsync("/api/getpayment");
            //client.Dispose();

            //bu işlemlerin yerine IHttpClientFactory => httpclientları yaratır, parametreleri set eder,otomatik dispose edilmesini(bellekten silinmesini),bağlantının kapatılmasını, aynı anda kaç tane client create edileceğini vs ayarlar


            var client = httpClientFactory.CreateClient("garantiAPI");
        }
        private Contact GetDummyContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "sdada",
                LastName = "dsadas"
            };
        }
    }
}
