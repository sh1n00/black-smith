using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blacksmith.Item {
    public class ItemMaker : MonoBehaviour {
        [SerializeField] ItemState itemState;
        [SerializeField] GameObject itemBase;
        [SerializeField] Transform[] positions;
        readonly float INTERVAL_MIN = 2f;
        readonly float INTERVAL_MAX = 5f;

        private void Start() {
            StartCoroutine(MakeLoop());
        }

        IEnumerator MakeLoop() {
            var interval = Random.Range(INTERVAL_MIN, INTERVAL_MAX);
            yield return new WaitForSeconds(interval);
            var makePos = positions[Random.Range(0, positions.Length)];
            var item = Instantiate(itemBase,makePos);
            //var makeIndex = Random.Range(0, items.Length);
            item.GetComponent<ItemBehaviour>().ItemInit(itemState,Type.TEST);//タイプはあとでmakeIndex使うように
            StartCoroutine(MakeLoop());
        }
    }
}
