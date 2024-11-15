using System;
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

        private void Start()
        {
            playForward.onClick.AddListener(() =>
            {
                animation.PlayForward();
            });
            playBackward.onClick.AddListener(() =>
            {
                animation.PlayBackward();
            });
            rewind.onClick.AddListener(() =>
            {
                animation.Rewind();
            });
            restart.onClick.AddListener(() =>
            {
                animation.Restart();
            });
            
        }
    }
}