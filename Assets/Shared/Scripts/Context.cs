using Shared.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public class Context
    {
        public static string Username = "";
        public static string BASE_API_URL = "https://localhost:5000";
        public static int? SelectedRouletteId = null;
        public static List<Item>? CurrentItemPool = null;
    }
}