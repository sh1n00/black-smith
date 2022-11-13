using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blacksmith.Item {
    public class ItemState : MonoBehaviour {
        //List<Type> activeItems = new List<Type>();
        [SerializeField] LerpMoveToTarget lerpMoveToTarget;
        public void RegisterItem(Type register) {
            switch (register) {
                case Type.STAN:
                    lerpMoveToTarget.ItemEffect(Type.STAN, true);
                    ItemEffectRemove(Type.STAN);
                    break;
            }
        }

        void ItemEffectRemove(Type type) {
            lerpMoveToTarget.ItemEffect(type, false);
        }
    }
}
