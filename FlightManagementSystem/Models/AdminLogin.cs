using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FlightManagementSystem.Models
{
    //TblAdminLogin
    [Table("TblAdminLogin")]
    public class AdminLogin
    {
       
   [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage ="User Name Required")]
        [Display(Name ="User Name")]
        [MinLength(5, ErrorMessage = "Minimum 3 char Required"), MaxLength(10, ErrorMessage = "Maximum 10 char Required")] 
        public string Adminname { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage ="Minimum 5 char Required"),MaxLength(10, ErrorMessage = "Maximum 10 char Required")]
        public string Password { get; set; }

    }
    [Table("TblUserAccount")]
    public class UserAccount
    {
       [Key] public int UserId { get; set; }

        [Display(Name ="first name")]
        [Required(ErrorMessage = "FirstName Required")]
        [MinLength(5, ErrorMessage = "Minimum 5 char Required"), MaxLength(20, ErrorMessage = "Maximum 20 char Required")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "LastName Required")]
        [MinLength(5, ErrorMessage = "Minimum 5 char Required"), MaxLength(20, ErrorMessage = "Maximum 20 char Required")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "EmailId Required")]
        [MinLength(5, ErrorMessage = "Minimum 5 char Required"), MaxLength(20, ErrorMessage = "Maximum 30 char Required")] 
       [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName Required")]
        [MinLength(5, ErrorMessage = "Minimum 5 char Required"), MaxLength(20, ErrorMessage = "Maximum 30 char Required")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [MinLength(5, ErrorMessage = "Minimum 5 char Required"), MaxLength(20, ErrorMessage = "Maximum 10 char Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Compare("Password",ErrorMessage ="Password does'nt Match")]
        [MinLength(5, ErrorMessage = "Minimum 5 char Required"), MaxLength(20, ErrorMessage = "Maximum 10 char Required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Age Required")]
        [Range(18,120,ErrorMessage ="Minimum 18 years should book")]
        public int Age { get; set; }

        [Display(Name = "Phone No")]
        [Required(ErrorMessage = "PhoneNo Required"),RegularExpression(@"^([0-9]{11})$",ErrorMessage ="Phone no is not Valid")]
        [StringLength(11)]
        public string PhoneNo { get; set; }

        [Display(Name = "Nic No")]
        [Required(ErrorMessage = "NICNo Required"), RegularExpression(@"^([0-9]{13})$", ErrorMessage = "NICNo is not Valid")]
        [StringLength(13)]
        public string NICNo { get; set; }

        //AdminFlight Table
        [Table("TblFlightInfo")]
        public class FlightInfo
        {
            [Key]
            public int FlightId { get; set; }

            [Required(ErrorMessage = "FlightName Required")]
            [Display(Name = "Flight Name")]
            [MinLength(3, ErrorMessage = "Minimum 3 char Required"), MaxLength(35, ErrorMessage = "Maximum 10 char Required")]
            public string FlightName { get; set; }

            [Required(ErrorMessage = "SeatingCapacity Required")]
            [Display(Name = "Seating Capacity")]
            
            public int SeatingCapacity { get; set; }

            [Required(ErrorMessage = "Price Required")]
            [Display(Name = "Price")]

            public float Price { get; set; }

            //Booking Table
        }
        [Table("TblFlightBooking")]
        public class FlightBooking
        {
            [Key]
            public int BId { get; set; }

            [Required(ErrorMessage = "From City Required")]
            [Display(Name = "From City")]
            [StringLength(40,ErrorMessage ="Max 40 Char Allowed")]

            public string From { get; set; }

            [Required(ErrorMessage = "To City Required")]
            [Display(Name = "To City")]
            [StringLength(40, ErrorMessage = "Max 40 Char Allowed")]

            public string To { get; set; }

            [Display(Name = "Departure Date")]
            [DataType(DataType.Date)]
            public DateTime DDate { get; set; }

            [Display(Name = "Departure Time")]
            [StringLength(15)]
            public string DTime { get; set; }

            public int FlightId { get; set; }
            public virtual FlightInfo FlightInformation { get; set; }

            [Display(Name = "Seat Type")]
            [StringLength(25)]
            public string SeatType { get; set; }
        }
        

    }
}