using Shared;
using Shared.Models;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ListMenu
{
    public class Core : MonoBehaviour
    {
        // referencje z edytora
        public GameObject listButtonPrefab;
        public GameObject canvas;

        // instancja core (singleton)
        private static Core INSTANCE;

        public static Core GetInstance()
        {
            if(!INSTANCE)
            {
                var gameObject = GameObject.FindGameObjectWithTag("LevelManager");
                INSTANCE = gameObject.GetComponent<Core>();
            }

            return INSTANCE;
        }

        public void RenderRouletteList()
        {
            int currY = -100;
            foreach (RouletteWithoutItems entry in Context.RouletteList)
            {
                GameObject button = CreateListButton(
                    entry.name,
                    () => {
                        Context.SelectedRouletteId = entry.Id;
                        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
                    }
                );

                // pozycja
                button.transform.localPosition = new Vector2(-510, currY);
                button.transform.SetParent(canvas.transform, true);

                currY -= 105;
            }
        }

        private GameObject CreateListButton(string label, UnityAction clickHandler)
        {
            GameObject button = Instantiate(listButtonPrefab, transform);

            // styl przycisku
            button.GetComponentInChildren<TMP_Text>().text = label;
            button.GetComponent<Image>().color = new Color(0.0274509803921569f, 0.0274509803921569f, 0.0274509803921569f);
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 75);

            // akcja przycisku
            button.GetComponent<Button>().onClick.AddListener(clickHandler);

            // dodatkowe opcje
            button.GetComponent<Image>().raycastTarget = false;

            return button;
        }
    }
}
