using Newtonsoft.Json;
using Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;

namespace ListMenu
{
    public class FetchRoulettes : MonoBehaviour
    {
        public GameObject listButtonPrefab;
        public GameObject canvas;

        public void Start()
        {
            Debug.Log(Shared.Context.Username);
            List<RouletteWithoutItems> records = Fetch();

            int currY = 100;

            foreach (RouletteWithoutItems entry in records)
            {
                GameObject button = Instantiate(listButtonPrefab, transform);
                button.GetComponentInChildren<TMPro.TMP_Text>().text = entry.name;
                button.GetComponent<Button>().onClick.AddListener(() => {
                    Shared.Context.SelectedRouletteId = entry.Id;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
                });

                button.transform.localPosition = new Vector3(40, currY, 0);
                button.transform.SetParent(canvas.transform, true);

                currY -= 60;
            }
        }

        private List<RouletteWithoutItems> Fetch()
        {
            try
            {
                HttpClient client = new HttpClient();
                string response = client.GetStringAsync($"{Shared.Context.BASE_API_URL}/Roulettes").Result;

                List<RouletteWithoutItems> records = JsonConvert.DeserializeObject<List<RouletteWithoutItems>>(response);
                return records;
            }
            catch (HttpRequestException e)
            {
                Debug.LogError($"Request error: {e.Message}");
                return new List<RouletteWithoutItems>();
            }
        }
    }
}