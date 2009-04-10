using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;

namespace DV_Enterprises.Web.BLL
{
    public class BaseEntity
    {
        protected static Cache Cache
        {
            get { return HttpContext.Current.Cache; }
        }

        public static IPrincipal CurrentUser
        {
            get { return HttpContext.Current.User; }
        }

        public static string CurrentUserName
        {
            get { return CurrentUser.Identity.IsAuthenticated ? CurrentUser.Identity.Name : String.Empty; }
        }

        public static string CurrentUserIP
        {
            get { return HttpContext.Current.Request.UserHostAddress; }
        }

        public static string ConvertNullToEmptyString(string input)
        {
            return input.Length == 0 ? "" : input;
        }

        public static void PurgeCachedItems(string prefix)
        {
            prefix = prefix.ToLower();
            var itemsToRemove = new List<string>();

            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().ToLower().StartsWith(prefix))
                    itemsToRemove.Add(enumerator.Key.ToString());
            }

            foreach (string itemToRemove in itemsToRemove)
                Cache.Remove(itemToRemove);
        }
    }
}