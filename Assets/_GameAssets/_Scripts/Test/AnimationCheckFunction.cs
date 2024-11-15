using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityHelper;

namespace _GameAssets._Scripts.Test
{
    public class AnimationCheckFunction : MonoBehaviour
    {
        public Button playForward;
        public Button playBackward;
        public Button rewind;
        public Button restart;

        [Header("--")]
        public DOTweenAnimationBase animation;

        public Transform tf;

        private Tweener Tweener;

        private void Awake()
        {
            Tweener = tf.DOScale(Vector3.one * 4, 1).OnComplete(() =>
            {
                Debug.Log("OnCreate");
            });
            Tweener.SetAutoKill(false);
            Tweener.Pause();
        }

        private void Start()
        {
            
            playForward.onClick.AddListener(() =>
            {
                Tweener.PlayForward();
            });
            playBackward.onClick.AddListener(() =>
            {
                Tweener.PlayBackwards();
            });
            rewind.onClick.AddListener(() =>
            {
                Tweener.Rewind();
            });
            restart.onClick.AddListener(() =>
            {
                Tweener.Restart();
            });
            
        }
    }
}