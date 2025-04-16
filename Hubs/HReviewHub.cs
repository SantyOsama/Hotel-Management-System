using HotelMangementSystem.Models.Database;
using HotelMangementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace HotelMangementSystem.Hubs
{
    public class HReviewHub : Hub
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DatabaseContext context;

        public HReviewHub(UserManager<ApplicationUser> userManager, DatabaseContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        public override Task OnConnectedAsync()
        {




            Clients.All.SendAsync("CheckConnect", "test String");

            // ClientsId.Add(context.)
            return base.OnConnectedAsync();
        }

    }
}
