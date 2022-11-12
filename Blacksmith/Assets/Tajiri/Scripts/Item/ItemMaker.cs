using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blacksmith.Item {
    public class ItemMaker : MonoBehaviour {
        [SerializeField] ItemState itemState;
        [SerializeField] GameObject itemBase;
        [SerializeField] Transform[] positions;
        bool[] isItemExists = new bool[9];
        GameObject[] itemPool = new GameObject[9];
        readonly float INTERVAL_MIN = 5f;
        readonly float INTERVAL_MAX = 10f;

        private void Start() {
            for (int i = 0; i < itemPool.Length; i++) {
                itemPool[i] = Instantiate(itemBase, transform);
                itemPool[i].SetActive(false);
            }
            StartCoroutine(MakeLoop());
        }
        /// <summary>
        /// ここで延々とアイテムを生成
        /// </summary>
        /// <returns></returns>
        IEnumerator MakeLoop() {
            float interval = Random.Range(INTERVAL_MIN, INTERVAL_MAX);
            yield return new WaitForSeconds(interval);
            Transform makePos = GetMakePosition();
            GameObject item = GetFreeItem();
            item.transform.position = makePos.position;
            item.SetActive(true);
            //var makeIndex = Random.Range(0,スプライトの数=タイプ );
            item.GetComponent<ItemBehaviour>().ItemInit(itemState, Type.STAN);
            StartCoroutine(MakeLoop());
        }

        /// <summary>
        /// プールから使ってないアイテムオブジェクトを取り出す
        /// </summary>
        /// <returns></returns>
        GameObject GetFreeItem() {
            foreach (var item in itemPool) {
                if (!item.activeSelf) {
                    return item;
                }
            }
            return Instantiate(itemBase, transform);//多分ここまで通らない
        }

        /// <summary>
        /// アイテムがまだ置かれていないどこかの地点の位置を取得　未実装　必要そうになれば
        /// </summary>
        /// <returns></returns>
        Transform GetMakePosition() {
            return positions[Random.Range(0, positions.Length)];
        }
    }
}
