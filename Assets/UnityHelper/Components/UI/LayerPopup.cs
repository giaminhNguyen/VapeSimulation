using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UnityHelper
{
    [RequireComponent(typeof(DOTweenScale))]
    public class LayerPopup : LayerBase
    {
        #region Properties

        [Header("References")]

        [SerializeField]
        private DOTweenScale _doTweenScale;
        
        [SerializeField]
        private Image _dimImage;

        [SerializeField]
        private Button _btnClose;
    
        [Header("--")]
        [SerializeField]
        private float _animTimeDim = 0.12f;
        
        private Tweener _dimTweener;

        private float _dimAlpha = 1;
        private float _timeAnimScale;
        
        #endregion

        protected override void OnValidate()
        {
            base.OnValidate();

            if (!_doTweenScale)
            {
                _doTweenScale = GetComponent<DOTweenScale>();
            }
        }

        protected override void InitAwake()
        {
            var color = _dimImage.color;
            _dimAlpha       = color.a;
            color.a         = 0;
            _dimImage.color = color;
            _dimTweener     = _dimImage.DOFade(_dimAlpha, _animTimeDim);
            _dimTweener.SetAutoKill(false);
            _dimTweener.Pause();
            _timeAnimScale  = _doTweenScale.Duration;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Open();
        }

        protected override void InitOnEnable()
        {
            var color = _dimImage.color;
            color.a         = 0;
            _dimImage.color = color;
        }

        protected override void InitStart()
        {
            _btnClose.onClick.AddListener(Close);
        }

        public override void Init()
        {
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Open()
        {
            base.Open();
            _dimTweener.PlayForward();
            DOVirtual.DelayedCall(_animTimeDim * 0.8f, _doTweenScale.PlayForward);
        }

        public override void Close()
        {
            base.Close();
            _doTweenScale.PlayBackward();
            DOVirtual.DelayedCall(_timeAnimScale * 0.8f, () =>
            {
                _dimTweener.PlayBackwards();
                DOVirtual.DelayedCall(_animTimeDim, () =>
                {
                    _doTweenScale.Rewind();
                    _dimTweener.Rewind();
                    gameObject.SetActive(false);
                });
            });
        }
    }
}