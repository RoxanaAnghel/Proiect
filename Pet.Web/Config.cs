using Pet.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Pet.Web
{
    public class Config : IConfig
    {
        private string _ConnectionString;
        public string ConnectionString
        {
            get
            {
                if (_ConnectionString == null)
                    _ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                return _ConnectionString;
            }
        }
    }
}