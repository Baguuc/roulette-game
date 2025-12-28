using MainScene;
using UnityEngine;

namespace MainMenu
{
    public class UsernameInputHandler : MonoBehaviour
    {
        // prywatny stan
        private Core core => Core.GetInstance();

        public void HandleEndEdit(string input)
        {
            Shared.Context.Username = input;
        }

        public void HandleSelect(string selection)
        {
            if (TouchScreenKeyboard.isSupported)
            {
                TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            }
            core.ToggleUsernameInputAlert(false);
        }
    }
}