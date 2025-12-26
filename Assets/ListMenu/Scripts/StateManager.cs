using UnityEngine;

namespace ListMenu
{
    public class StateManager : MonoBehaviour
    {
        private static StateManager INSTANCE;

        public static StateManager GetInstance()
        {
            if(!INSTANCE)
            {
                var gameObject = GameObject.FindGameObjectWithTag("UIManager");
                INSTANCE = gameObject.GetComponent<StateManager>();
            }

            return INSTANCE;
        }
    }
}
