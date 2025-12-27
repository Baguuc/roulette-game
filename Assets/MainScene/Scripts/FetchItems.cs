using Newtonsoft.Json;
using Shared;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TMPro;
using UnityEngine;

namespace MainScene
{
    public class FetchRoulettes : MonoBehaviour
    {
        public List<TMP_Text> panelTextContainers;
        
        System.Random random = new System.Random();

        public void Start()
        {
            if(Shared.Context.SelectedRouletteId == null)
            {
                Debug.LogError("No roulette selected!");
                return;
            }

            Roulette record = Fetch(Shared.Context.SelectedRouletteId ?? 0);
            if(record == null)
            {
                Debug.LogError("Failed to fetch roulette data!");
                return;
            }

            List<Item> roulettePool = new List<Item>();
            int i = record.items.Count;
            foreach (Item item in record.items.OrderBy(item => item.Value))
            {
                for(int j = 0; j < i; j++)
                {
                    roulettePool.Add(item);
                }

                i--;
            }

            Shared.Context.CurrentItemPool = random.Shuffle<Item>(roulettePool);
            Utils.RenderCurrentItemPool(panelTextContainers);
        }

        private Roulette? Fetch(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                string response = client.GetStringAsync($"{Shared.Context.BASE_API_URL}/Roulettes/Details/{id}").Result;

                Roulette record = JsonConvert.DeserializeObject<Roulette>(response);
                return record;
            }
            catch (HttpRequestException e)
            {
                Debug.LogError($"Request error: {e.Message}");
                return null;
            }
        }
    }
}