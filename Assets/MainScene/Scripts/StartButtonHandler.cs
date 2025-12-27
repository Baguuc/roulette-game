using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using TMPro;
using UnityEngine;

namespace MainScene
{
    public class StartButtonHandler : MonoBehaviour
    {
        public List<TMP_Text> panelTextContainers;

        public void OnClick()
        {
            if (Shared.Context.CurrentItemPool == null || Shared.Context.CurrentItemPool.Count < 5)
            {
                return;
            }

            StartCoroutine(Roll());
        }

        private GeneratedReward? RollAReward()
        {
            try
            {
                HttpClient client = new HttpClient();

                var bodyData = new { Username = Shared.Context.Username, RouletteId = Shared.Context.SelectedRouletteId };
                string bodyJson = JsonConvert.SerializeObject(bodyData);
                HttpContent content = new StringContent(bodyJson);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = client.PostAsync($"{Shared.Context.BASE_API_URL}/Rewards", content).Result;

                string responseBody = response.Content.ReadAsStringAsync().Result;

                GeneratedReward reward = JsonConvert.DeserializeObject<GeneratedReward>(responseBody);
                return reward;
            }
            catch (Exception e)
            {
                Debug.LogError($"Request error: {e.Message}");
                return null;
            }
        }

        IEnumerator Roll()
        {
            GeneratedReward reward = RollAReward();

            // obróæ siê w pe³ni 2 razy (wykonaj <iloœæ wejœæ w currentItemPool> przesuniêæ) dla imitacji losowoœci
            for (int i = 0; i < Shared.Context.CurrentItemPool.Count * 2; i++)
            {
                Utils.RotateCurrentItemPool();
                Utils.RenderCurrentItemPool(panelTextContainers);

                yield return new WaitForSeconds(0.1f);
            }

            // dopóki wylosowany element nie jest na œrodku ekranu, przesuwaj elementy
            while (Shared.Context.CurrentItemPool[2].id != reward.itemId)
            {
                Utils.RotateCurrentItemPool();
                Utils.RenderCurrentItemPool(panelTextContainers);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}