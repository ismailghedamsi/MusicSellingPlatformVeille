
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MusicSellingApp.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StartPaymentController : ControllerBase
    {
        [Inject]  ILocalStorageService localStorage { get; set; }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //int quanity = await localStorage.GetItemAsync<int>("quantity");
            StripeConfiguration.ApiKey = "sk_test_51HakXCLFPzNgSBSAsmCE2RO37Zo89BoOkSEZgleUHByO1uXIk7bINT13OB8csqNMkoNwAXVyPwt5DqdDPH3EUaQl00tMImYyfH"; //Get it from your stripe dashboard

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                    "ideal"
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Name = $"Pants with 3 legs",
                        Description = $"Pants for those who have 3 legs",
                        Amount = 100, // 1 euro
                        Currency = "eur",
                        Quantity = 2
                    }
                },
                SuccessUrl = "https://localhost:44368/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://localhost:44368/failed"
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return Ok(session.Id);
        }
    }
}
