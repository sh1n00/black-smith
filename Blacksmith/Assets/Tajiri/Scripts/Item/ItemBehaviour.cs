using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Blacksmith.Item {
    public class ItemBehaviour : MonoBehaviour {
        ItemState itemState;
        SoundManager soundManager;
        Type myItem;
        [SerializeField] Vector3 bigPos;

        /// <summary>
        /// �A�C�e���̏������@�����ŃX�v���C�g���n���悤�ɂ���
        /// </summary>
        /// <param name="stateReference"></param>
        /// <param name="set"></param>
        public void ItemInit(ItemState stateReference,SoundManager soundReference,Type set) {
            itemState = stateReference;
            soundManager = soundReference;
            myItem = set;
            transform.parent = null;
        }

        public void ItemTake() {
            itemState.RegisterItem(myItem);
            soundManager.ItemGetPlay();
            transform.DOScale(bigPos, 0.3f).OnComplete(() => {
                gameObject.SetActive(false);
                transform.localScale = Vector3.one;
            });
        }
    }
}