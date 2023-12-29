using System;
using Cysharp.Threading.Tasks;
using Entities;
using UnityEngine;

namespace Abilities.Data
{
    [CreateAssetMenu(fileName = "Pyre", menuName = "Skills/Pyre")]
    class Pyre : AbilityData
    {
        [SerializeField]
        float _baseDamage;

        [SerializeField]
        float _baseDuration;

        [SerializeField]
        float _baseInterval;

        [SerializeField]
        ITargetProvider _targetProvider;

        public override async UniTask Execute(IEntity caster)
        {
            TimeSpan elapsed = TimeSpan.Zero;
            while (elapsed < caster.CalculateDuration(_baseDuration))
            {
                TimeSpan interval = caster.CalculateInterval(_baseInterval);
                IEntity target = await _targetProvider.GetTarget(caster);
                target.TakeDamage(caster.CalculateDamage(_baseDamage));
                elapsed = elapsed.Add(interval);
                await UniTask.Delay(interval);
            }
        }
    }
}