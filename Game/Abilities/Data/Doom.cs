using System;
using Cysharp.Threading.Tasks;
using Entities;
using UnityEngine;

namespace Abilities.Data
{
    [CreateAssetMenu(fileName = "Doom", menuName = "Skills/Doom")]
    class Doom : AbilityData
    {
        [SerializeField]
        AbilityData _effectAbility;

        [SerializeField]
        float _baseCooldown;

        [SerializeField]
        ITargetProvider _targetProvider;

        public override async UniTask Execute(IEntity caster)
        {
            _ = await _targetProvider.GetTarget(caster);
            _ = new AbilityCommand(caster, _effectAbility).Execute();

            TimeSpan cooldown = caster.CalculateInterval(_baseCooldown);
            await UniTask.Delay(cooldown);
        }
    }
}