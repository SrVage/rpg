using Code.Components;
using Code.Components.Audio;
using Code.Config;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Gameplay
{
    internal sealed class PlayAudioSystem:IEcsRunSystem
    {
        private AudioSource _audioSource;
        private readonly SoundsConfig _soundsConfig = null;
        private readonly EcsFilter<StepAudio> _step = null;
        private readonly EcsFilter<AttackAudio> _attack = null;

        public void Run()
        {
            if (_audioSource==null)
                _audioSource = Object.FindObjectOfType<AudioSource>();
            if (!_step.IsEmpty())
                _audioSource.PlayOneShot(_soundsConfig.PlayerStep);
            if (!_attack.IsEmpty())
            {
                foreach (var adx in _attack)
                {
                    if (_attack.GetEntity(adx).Has<PlayerTag>())
                        _audioSource.PlayOneShot(_soundsConfig.PlayerAttack);
                    else
                        _audioSource.PlayOneShot(_soundsConfig.EnemyAttack);
                }
            }
        }
    }
}