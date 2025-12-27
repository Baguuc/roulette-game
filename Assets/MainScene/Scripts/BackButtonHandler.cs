using Shared;
using UnityEngine;

namespace MainScene
{
    public class BackButtonHandler : MonoBehaviour
    {
        public void HandleClick()
        {
            Context.SelectedRouletteId = null;
            Context.CurrentItemPool = null;
            UnityEngine.SceneManagement.SceneManager.LoadScene("ListMenu");
        }
    }
}
