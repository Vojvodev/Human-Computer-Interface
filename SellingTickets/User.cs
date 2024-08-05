using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingTickets
{
    internal class User
    {
        public int id           { get; set; }
        public string username  { get; set; }
        public string password  { get; set; }
        public string fname     { get; set; }
        public string lname     { get; set; }
        public string phone     { get; set; }
        public string email     { get; set; }
        public string location  { get; set; }
        public Boolean isAdmin = false; 
        public Boolean isBlocked = false;
        
        public Boolean getIsAdmin() { return isAdmin; }
        public Boolean getIsBlocked() {  return isBlocked; }
        public void setIsBlocked(Boolean isBlocked) { this.isBlocked = isBlocked; }
        public void setIsAdmin(Boolean isAdmin) { this.isAdmin = isAdmin; }
    
    }

}
