using System;
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
        public DateTime DateCreated { get; private set;}
        public DateTime DateUpdated { get; private set; }
        

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Address's
        /// </summary>
        /// <returns>return an IQueryable collection of Address</returns>
        public static IEnumerable<Address> All()
        {
            return All(null);   
        }

        /// <summary>
        /// Find all Address's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of Address</returns>
        public static IEnumerable<Address> All(DataContext dc)
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
                                   IsDefault = a.IsDefault,
                                   DateCreated = a.DateCreated,
                                   DateUpdated = a.DateUpdated
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
            var address = All(dc).Where(a => a.ID == id).SingleOrDefault();
            return address ?? new Address {ID = 0};
        }

        /// <summary>
        /// Save a Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns>returns the id of the saved model</returns>
        public static int Save(Address address)
        {
            return Save(null, address);
        }

        /// <summary>
        /// Save a Address
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="address"></param>
        /// <returns>returns the id of the saved model</returns>
        public static int Save(DataContext dc, Address address)
        {
            dc = dc ?? Conn.GetContext();
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
            dbAddress.DateUpdated = DateTime.Now;

            if (isNew)
            {
                dbAddress.DateCreated = DateTime.Now;
                dc.Addresses.InsertOnSubmit(dbAddress);
            }
            dc.SubmitChanges();
            return dbAddress.AddressID;
        }

        /// <summary>
        /// Delete a single 
        /// </summary>
        /// <param name="address"></param>
        public static void Delete(Address address)
        {
            Delete(null, address);
        }

        /// <summary>
        /// Delete a single 
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="address"></param>
        public static void Delete(DataContext dc, Address address)
        {
            dc = dc ?? Conn.GetContext();
            var dbAddress = dc.Addresses.Where(a => a.AddressID == address.ID).SingleOrDefault();
            if (dbAddress == null) return;
            dc.Addresses.Attach(dbAddress, true);
            dc.Addresses.DeleteOnSubmit(dbAddress);
            dc.SubmitChanges();
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
        /// Save Address
        /// </summary>
        /// <returns>returns the id of the saved model</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }

        /// <summary>
        /// Delete Address
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Address
        /// </summary>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion
    }
}