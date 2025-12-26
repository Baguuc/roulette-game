using Newtonsoft.Json;
using Shared.Models;
using System.Collections.Generic;
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
            for(int i = 0; i < record.items.Count * 2; i++)
            {
                Item item = Shared.Utils.WeightedPick(record.items, random);
                roulettePool.Add(item);
            }

            Shared.Context.CurrentItemPool = roulettePool;

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