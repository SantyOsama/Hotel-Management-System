using HotelMangementSystem.Models;
using static HotelMangementSystem.Models.Enums.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using HotelMangementSystem.Validations;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangementSystem.ViewModels
{
    public class ReservitionViewModel
    {
        public DateTime BookingDate { get; set; }
        [DontAllowFutureDate]
        [Remote("ValidateDate", "Validation")]

        public DateTime CheckInDate { get; set; }

        [Remote("ValidateCheckOutDate", "Validation", AdditionalFields = "CheckInDate")]

        public DateTime CheckOutDate { get; set; }
        //public int Deposite { get; set; }B
        public ReservistionStatuses ReservistionStatus { get; set; }


        public bool IsDeleted { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Bill")]
        public int BillId { get; set; }


        public List<Room>? Rooms { get; set; }



        public Bill? Bill { get; set; }
        public ApplicationUser? User { get; set; }

        public RoomReservation? RoomReservation { get; set; }
    }
}
