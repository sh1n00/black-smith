using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blacksmith.Item {
    public class ItemState : MonoBehaviour {
        List<Type> activeItems = new List<Type>();

        public  void RegisterItem(Type register) {
            activeItems.Add(register);
            foreach (var item in activeItems) {
                Debug.Log(item.ToString());
            }}
    }
}
