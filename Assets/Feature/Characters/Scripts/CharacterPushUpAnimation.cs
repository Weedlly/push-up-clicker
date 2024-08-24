using System;
using UnityEngine;

namespace Feature.Characters.Scripts
{
    [Serializable]
    public class CharacterPushUpAnimation
    {
        [SerializeField] private Animator _animator;

        private int _stepIdx;
        private static readonly int S1 = Animator.StringToHash("S1");
        private static readonly int S2 = Animator.StringToHash("S2");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public void Setup()
        {
            _animator.SetTrigger(Idle);
        }
        public void PlayAnim()
        {
            switch (_stepIdx)
            {
                case 0:
                    {
                        _animator.SetTrigger(S1);
                        _stepIdx = 1;
                        break;
                    }
                case 1:
                    {
                        _animator.SetTrigger(S2);
                        _stepIdx = 2;
                        break;
                    }
                case 2:
                    {
                        _animator.SetTrigger(Idle);
                        _animator.SetTrigger(S1);
                        _stepIdx = 1;
                        break;
                    }
            }
        }
        public bool IsFinalStep() => _stepIdx == 2;
    }
}
