using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tavisca.Templar.UIAutomation.Extensions.Helpers
{
    public static class TimeoutSettings
    {
        public static class Air
        {
            public static readonly long GetAdditionalOptions = 120000;
            public static readonly long GetResults = 120000;
            public static readonly long AddToCart = 120000;
        }

        public static class Hotel
        {
            public static readonly long GetAdditionalOptions = 120000;
            public static readonly long GetResults = 120000;
            public static readonly long GetRooms = 120000;
            public static readonly long AddToCart = 120000;
        }

        public static class Car
        {
            public static readonly long GetResults = 120000;
            public static readonly long AddToCart = 120000;
            public static readonly long SearchRedirection = 5000;
        }

        public static class Activity
        {
            public static readonly long GetResults = 120000;
            public static readonly long GetOptions = 120000;
            public static readonly long AddToCart = 120000;
        }

        public static class Pages
        {
            public static readonly long Checkout = 120000;
            public static readonly long Login = 120000;
            public static readonly long Registration = 120000;
            public static readonly long ProfilePage = 120000;
            public static readonly long Confirmation = 120000;
        }
    }
}
