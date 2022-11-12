using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blacksmith.Item {
    public class ItemBehaviour : MonoBehaviour {
        ItemState itemState;
        Type myItem;

        /// <summary>
        /// アイテムの初期化　ここでスプライトも渡すようにする
        /// </summary>
        /// <param name="stateReference"></param>
        /// <param name="set"></param>
        public void ItemInit(ItemState stateReference,Type set) {
            itemState = stateReference;
            myItem = set;
            transform.parent = null;
        }

        public void ItemTake() {
            itemState.RegisterItem(myItem);
            gameObject.SetActive(false);
        }
    }
}