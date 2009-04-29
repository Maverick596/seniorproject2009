using System;
using System.Web;

namespace DV_Enterprises.Web.Core.Impl
{
    public class WebContext : IWebContext
    {

        public Guid AccoutID
        {
            get
            {
                Guid accountID;
                if (!string.IsNullOrEmpty(GetQueryStringValue("AccountID")))
                {
                    accountID = new Guid(GetQueryStringValue("AccountID"));
                }
                else
                {
                    accountID = new Guid("0");
                }
                return accountID;
            }
        }

        public bool LoggedIn
        {
            get
            {
                if (ContainsInSession("LoggedIn"))
                {
                    if ((bool)GetFromSession("LoggedIn"))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                SetInSession("LoggedIn", value);
            }
        }

        public string UsernameToVerify
        {
            get { throw new NotImplementedException(); }
        }

        public bool ContainsInSession(string key)
        {
            return HttpContext.Current.Session != null && HttpContext.Current.Session[key] != null;
        }

        private string GetQueryStringValue(string key)
        {
            return HttpContext.Current.Request.QueryString.Get(key);
        }

        private void SetInSession(string key, object value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return;
            }
            HttpContext.Current.Session[key] = value;
        }

        private object GetFromSession(string key)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return null;
            }
            return HttpContext.Current.Session[key];
        }
    }
}