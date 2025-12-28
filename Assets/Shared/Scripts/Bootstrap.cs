using UMI;
using UnityEngine;

namespace Shared
{
    public class Bootstrap : MonoBehaviour
    {

        public void Awake()
        {
            MobileInput.Init();
        }
    }
}