using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Abstract;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Address : DomainModel, IAddress
    {
        #region Static properties

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public bool IsDefault { get; set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Address's
        /// </summary>
        /// <returns>return an IQueryable collection of Address</returns>
        public static IList<Address> All()
        {
            return All(null);   
        }

        /// <summary>
        /// Find all Address's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of Address</returns>
        public static IList<Address> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from a in dc.Addresses
                    select new Address
                               {
                                   ID = a.AddressID,
                                   City = a.City,
                                   StateOrProvince = a.StateOrProvince,
                                   Country = a.Country,
                                   Zip = a.Zip,
                                   StreetLine1 = a.StreetLine1,
                                   StreetLine2 = a.StreetLine2,
                                   IsDefault = a.IsDefault
                               };
            return r.ToList();
        }

        /// <summary>
        /// Find an Address by it's id.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>returns a Address</returns>
        public static Address Find(int id)
        {
            return Find(null, id);
        }

        /// <summary>
        /// Find an Address by it's id.
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="id">ID</param>
        /// <returns>returns a Address</returns>
        public static Address Find(DataContext dc, int id)
        {
            var g = All(dc).Where(l => l.ID == id).SingleOrDefault();
            return g ?? new Address {ID = 0};
        }

        /// <summary>
        /// Save a Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns>returns the id of the saved model</returns>
        public static int Save(Address address)
        {
            using (var dc  = Conn.GetContext())
            {
                var dbAddress = dc.Addresses.Where(a => a.AddressID == address.ID).SingleOrDefault();
                var isNew = false;
                if (dbAddress == null)
                {
                    dbAddress = new DataAccess.SqlRepository.Address();
                    isNew = true;
                }

                dbAddress.City = address.City;
                dbAddress.Country = address.Country;
                dbAddress.StateOrProvince = address.StateOrProvince;
                dbAddress.Zip = address.Zip;
                dbAddress.StreetLine1 = address.StreetLine1;
                dbAddress.StreetLine2 = address.StreetLine2;
                dbAddress.IsDefault = address.IsDefault;

                if(isNew)
                    dc.Addresses.InsertOnSubmit(dbAddress);
                dc.SubmitChanges();
                return dbAddress.AddressID;
            }
        }

        /// <summary>
        /// Delete a single 
        /// </summary>
        /// <param name="address"></param>
        public static void Delete(Address address)
        {
            using (var dc = Conn.GetContext())
            {
                var dbAddress = dc.Addresses.Where(a => a.AddressID == address.ID).SingleOrDefault();
                if (dbAddress == null) return;
                dc.Addresses.Attach(dbAddress, true);
                dc.Addresses.DeleteOnSubmit(dbAddress);
                dc.SubmitChanges();
            }
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Address
        /// </summary>
        /// <returns>returns the id of the saved model</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Delete Address
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        #endregion
    }
}