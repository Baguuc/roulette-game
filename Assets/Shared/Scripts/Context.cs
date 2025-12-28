using Shared.Models;
using System.Collections.Generic;

namespace Shared
{
    public class Context
    {
        // sta³e
        public static string BASE_API_URL = "http://192.168.0.34:5048";

        // globalny stan aplikacji
        public static string Username = null;
        public static List<RouletteWithoutItems> RouletteList = null;
        public static int? SelectedRouletteId = null;
        public static List<Item> CurrentItemPool = null;
    }
}