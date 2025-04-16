using HotelMangementSystem.Models;
using HotelMangementSystem.Models.Database;
using HotelMangementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace HotelMangementSystem.Hubs
{
    public class HAddHotelHub : Hub
    {
        static public Dictionary<string, string> ClientsId = new Dictionary<string, string>();
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DatabaseContext context;

        public HAddHotelHub(UserManager<ApplicationUser> userManager, DatabaseContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public override Task OnConnectedAsync()
        {
            string name;
            if (Context.User.Identity.Name != null)
            {

                name = Context.User.Identity.Name;
            }
            else
            {
                name = "guest";
            }

            string id = Context.ConnectionId;

            if (Clients.Caller != null)
            {

                ClientsId[name] = id;
            }

            Clients.All.SendAsync("CheckConnect", name, id);

            // ClientsId.Add(context.)
            return base.OnConnectedAsync();
        }
        public void SendRequest(string name, string description, int starRatig, string location, string phoneNumber, int numberOfRooms, string managerId, int cityId)
        {

        }
        public void test(string name)
        {

        }

    }
}
