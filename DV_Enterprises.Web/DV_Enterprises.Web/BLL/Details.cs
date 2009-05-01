using System;

namespace DV_Enterprises.Web.BLL
{
    [Serializable]
    public class Details
    {
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Name { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
    }
}