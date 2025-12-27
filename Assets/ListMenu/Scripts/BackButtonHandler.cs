using Shared;
using UnityEngine;

namespace ListMenu
{
    public class BackButtonHandler : MonoBehaviour
    {
        public void HandleClick()
        {
            Context.Username = "";
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}