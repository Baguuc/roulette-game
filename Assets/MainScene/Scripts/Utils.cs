using Shared.Models;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MainScene
{
    public class Utils
    {
        public static void RenderCurrentItemPool(List<TMP_Text> panelTextContainers)
        {
            if (Shared.Context.CurrentItemPool == null || Shared.Context.CurrentItemPool.Count < 5)
            {
                Debug.LogError("current item pool has less than 5 items.");
                return;
            }

            int j = 0;
            foreach (TMP_Text textContainer in panelTextContainers)
            {
                if (Shared.Context.CurrentItemPool.Count < j + 1)
                {
                    Debug.LogError("Not enough items in roulette pool!");
                    break;
                }

                Item item = Shared.Context.CurrentItemPool[j];
                textContainer.text = item.name;
                j++;
            }
        }

        public static void RotateCurrentItemPool()
        {
            if (Shared.Context.CurrentItemPool == null || Shared.Context.CurrentItemPool.Count < 1)
            {
                Debug.LogError("current item pool is empty.");
                return;
            }

            Item first = Shared.Context.CurrentItemPool[0];
            Shared.Context.CurrentItemPool.RemoveAt(0);
            Shared.Context.CurrentItemPool.Add(first);
        }
    }
}