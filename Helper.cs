using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NTierDemoApp
{
    public static class Helper
    {
        public static string ConnectionString =>
            System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
    }

    public enum ActionType
    {
        Insert = 1,
        Update,
        Delete
    }
}
