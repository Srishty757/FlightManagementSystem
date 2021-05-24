using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace FlightManagementSystem.Models
{
    public class ContextCS : DbContext
    {
        public ContextCS() : base("cs")
        {

        }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccount.FlightInfo> flightInfos { get; set; }
        public DbSet<UserAccount.FlightBooking> FlightBookings { get; set; }


    }
}