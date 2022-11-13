using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Blacksmith.Item {
    public class ItemState : MonoBehaviour {
        //List<Type> activeItems = new List<Type>();
        [SerializeField] LerpMoveToTarget lerpMoveToTarget;
        [SerializeField] float stanTime;
        public void RegisterItem(Type register) {
            switch (register) {
                case Type.STAN:
                    lerpMoveToTarget.ItemEffect(Type.STAN, true);
                    StartCoroutine(ItemEffectRemove(Type.STAN));
                    break;
            }
        }

        IEnumerator ItemEffectRemove(Type type) {
            yield return new WaitForSeconds(stanTime);
            lerpMoveToTarget.ItemEffect(type, false);
        }
    }
}
