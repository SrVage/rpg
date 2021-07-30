using System;
using UnityEngine;

namespace Code.View
{
    public class PlayerView:MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayWalkAnimation(Vector3 moveTarget)
        {
            _animator.SetBool("isWalking", true);
            _animator.SetFloat("Speed", Mathf.Clamp((moveTarget - transform.position).magnitude*0.5f, 0, 10));
        }

        public void PlayIdleAnimation()
        {
            _animator.SetBool("isWalking", false);
        }
    }
}