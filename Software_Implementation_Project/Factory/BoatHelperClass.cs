using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Software_Implementation_Project.Factory
{
    public static class BoatHelperClass
    {
        
        public static void showDetails(Boat boat)
        {
            Type type = typeof(Software_Implementation_Project.Factory.IBoat);
            string details = string.Empty;
            var propertyInfos = boat.GetType().GetProperties();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (System.Reflection.PropertyInfo prop in propertyInfos)
            {
                string strFieldName = prop.Name;
                properties.Add(prop.Name, prop.GetValue(boat, null));
            }

            foreach (KeyValuePair<string, object> item in properties)
            {
                details += string.Format(" {0}= {1}", item.Key, item.Value) + "\n";
            }
            Console.WriteLine(details);
        }
        public static string FormatCurrency(this decimal amount, string currencyCode)
        {
            //https://lukencode.com/2012/05/28/quick-and-dirty-csharp-currency-helper/
            var culture = (from c in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                           let r = new RegionInfo(c.LCID)
                           where r != null
                           && r.ISOCurrencySymbol.ToUpper() == currencyCode.ToUpper()
                           select c).FirstOrDefault();

            if (culture == null)
                return amount.ToString("0.00");

            return string.Format(culture, "{0:C}", amount);
        }
    }
}
