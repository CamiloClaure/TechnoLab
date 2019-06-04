using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace clsGeneric.Controller
{
    public static class clsUtil
    {
        public static T mtdisNull<T>(this T v1, T defaultValue)
        {
            return v1 == null ? defaultValue : v1;
        }


        public static string mtdToJSON(object luObj)
        {
            return JsonConvert.SerializeObject(luObj);
        }

        public static T mtdJsonToObj<T>(string luObj)
        {
            return JsonConvert.DeserializeObject<T>(luObj);
        }

        public static DateTime mtdCurrentDate()
        {
            return DateTime.Now;
        }

    }
}
