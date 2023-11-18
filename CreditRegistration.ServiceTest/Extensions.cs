﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistration.ServiceTest
{
    public static class Extensions
    {
        public static T Deserialize<T>(this HttpResponseMessage source)
        {

            var str = source.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(source.Content.ReadAsStringAsync().Result);
        }
    }
}
