using Shared;
using UnityEngine;

namespace MainMenu
{
    public class StartButtonHandler : MonoBehaviour
    {
        public void HandleClick()
        {
            Core core = Core.GetInstance();

            // nazwa u¿ytkownika nie zosta³a wprowadzona a nie mo¿e byæ pusta
            // wiêc poinformuj u¿ytkownika przez zmianê koloru pola na czerwony
            if (Context.Username.Length == 0)
            {
                core.ToggleUsernameInputAlert(true);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("ListMenu");
            }
        }
    }
}