using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;

namespace Feature.Home.Scripts
{
    [Serializable]
    public class PushUpRewardingEffect
    {
        [SerializeField] private float _effectDuration;
        [SerializeField] private Transform _startPos;
        [SerializeField] private Transform _coinDesPos;
        [SerializeField] private Transform _powerDesPos;
        [SerializeField] private GameObject _powerGo;
        [SerializeField] private GameObject _coinGo;

        private Tween _movingPowerTween;
        private Tween _movingCoinTween;
        public async UniTask PlayAnim()
        {
            if (_movingPowerTween.IsActive())
            {
                _movingPowerTween.Kill();
            }
            if (_movingCoinTween.IsActive())
            {
                _movingCoinTween.Kill();
            }
            _powerGo.transform.position = _startPos.position;
            _coinGo.transform.position = _startPos.position;

            _powerGo.SetActive(true);
            _coinGo.SetActive(true);

            _movingPowerTween = _powerGo.transform.DOMove(_powerDesPos.transform.position, _effectDuration)
                .OnComplete(() =>
                {
                    _powerGo.SetActive(false);
                    _coinGo.SetActive(false);
                });
             _coinGo.transform.DOMove(_coinDesPos.transform.position, _effectDuration)
                .OnComplete(() =>
                {
                    _powerGo.SetActive(false);
                    _coinGo.SetActive(false);
                });
            UniTask.Delay(TimeSpan.FromSeconds(_effectDuration));
        }
    }
}
