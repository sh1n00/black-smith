using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blacksmith.Item {
    public class ItemBehaviour : MonoBehaviour {
        ItemState itemState;
        Type myItem;

        public void ItemInit(Type set) {
            myItem = set;
        }

        public void ItemTake() {
            itemState.RegisterItem(myItem);
            gameObject.SetActive(false);
        }
    }
}