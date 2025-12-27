using Shared;
using UnityEngine;

namespace MainMenu
{
    public class ExitButtonHandler : MonoBehaviour
    {
        public void HandleClick()
        {
            Utils.Exit();
        }
    }
}