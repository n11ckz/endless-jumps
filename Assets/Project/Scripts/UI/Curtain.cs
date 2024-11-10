using PrimeTween;
using System.Collections;
using UnityEngine;

namespace Project
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField, Range(0.0f, 1.0f)] private float _fadeDuration = 0.35f;
        [SerializeField, Range(0.0f, 1.0f)] private float _delayBeforeHide = 0.7f;

        public bool IsHidden { get; private set; }

        public IEnumerator Show()
        {
            IsHidden = false;
            gameObject.Activate();

            return Tween.Alpha(_canvasGroup, 1.0f, _fadeDuration).ToYieldInstruction();
        }

        public void HideWithDelay()
        {
            IsHidden = true;
            Tween.Delay(_delayBeforeHide, () => Hide());
        }

        private void Hide() => Tween.Alpha(_canvasGroup, 0.0f, _fadeDuration).OnComplete(() => gameObject.Deactivate());
    }
}
