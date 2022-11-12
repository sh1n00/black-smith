using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blacksmith.Item {
    public class ItemState : MonoBehaviour {
        //List<Type> activeItems = new List<Type>();
        [SerializeField] SandBag sandBag;
        public void RegisterItem(Type register) {
            switch (register) {
                case Type.STAN:
                    sandBag.ItemEffect(Type.STAN, true);
                    ItemEffectRemove(Type.STAN);
                    break;
            }
        }

        void ItemEffectRemove(Type type) {
            sandBag.ItemEffect(type, false);
        }
    }
}
