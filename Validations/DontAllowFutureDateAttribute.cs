using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangementSystem.Validations
{

    public class DontAllowFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime.Date < DateTime.Today)
                {
                    return new ValidationResult("The date cannot be earlier than today.");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class ValidationController : Controller
    {
        public IActionResult ValidateDate(DateTime CheckInDate)
        {
            if (CheckInDate < DateTime.Today)
            {
                return Json("The date cannot be earlier than today.");
            }
            return Json(true); // Validation passed
        }


        public JsonResult ValidateCheckOutDate(DateTime checkInDate, DateTime checkOutDate)
        {
            if (checkOutDate < DateTime.Today)
            {
                return Json("The date cannot be earlier than today.");
            }

            if (checkInDate == checkOutDate)
            {
                return Json("Check-out date cannot be the same as check-in date.");
            }

            return Json(true);
        }

    }



}
