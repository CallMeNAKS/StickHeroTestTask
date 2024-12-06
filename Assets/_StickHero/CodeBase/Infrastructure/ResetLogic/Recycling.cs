using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.ResetLogic
{
    public class Recycling
    {
        private List<GameObject> _itemsForRecycling = new List<GameObject>();

        public void AddItemToRecycling(GameObject item)
        {
            _itemsForRecycling.Add(item);
        }

        public void Clear()
        {
            foreach (var gameObject in _itemsForRecycling)
            {
                gameObject.SetActive(false);
            }
        }
    }
}