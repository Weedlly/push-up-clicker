using System;
using UnityEngine;

namespace Feature.Characters.Scripts
{
    public class BallPositionHandle : MonoBehaviour
    {
        [SerializeField] private Transform _anchorPos;
        [SerializeField] private Vector3 _offset;

        private void Awake()
        {
            transform.position = _anchorPos.position + _offset;
        }
        private void Update()
        {
            transform.position = _anchorPos.position + _offset;
        }
    }
}
