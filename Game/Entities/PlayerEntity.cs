using System;
using System.Collections.Generic;
using Abilities;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Entities
{
    class PlayerEntity : SerializedMonoBehaviour, IEntity
    {
        [SerializeField]
        List<IAbility> _abilities;

        [Inject]
        AbilitySystemFactory _abilitySystemFactory;

        AbilitySystem _abilitySystem;

        public Vector3 Origin => transform.position;

        void Start()
        {
            _abilitySystem = _abilitySystemFactory.Create(this, _abilities);
        }

        void Update()
        {
            _abilitySystem.Cast();
        }

        public TimeSpan CalculateDelay(float baseDelay)
        {
            return default;
        }

        public float CalculateDamage(float baseDamage)
        {
            return 0;
        }

        public TimeSpan CalculateDuration(TimeSpan baseDuration)
        {
            return default;
        }

        public TimeSpan CalculateInterval(TimeSpan interval)
        {
            return default;
        }

        public bool IsAlive()
        {
            return false;
        }

        public void TakeDamage(float damage) { }
    }
}