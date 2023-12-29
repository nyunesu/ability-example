using System;
using Cysharp.Threading.Tasks;
using Entities;
using UnityEngine;

namespace Abilities.Data
{
    [CreateAssetMenu(fileName = "DoomCurse", menuName = "Skills/DoomCurse")]
    class DoomCurse : AbilityData
    {
        [SerializeField]
        float _baseDamage;

        [SerializeField]
        AbilityData _onDeathAbility;

        [SerializeField]
        float _baseInterval;

        [SerializeField]
        ITargetProvider _targetProvider;

        public override async UniTask Execute(IEntity caster)
        {
            IEntity target = await _targetProvider.GetTarget(caster);
            while (target.IsAlive())
            {
                float damage = caster.CalculateDamage(_baseDamage);
                target.TakeDamage(damage);

                TimeSpan interval = caster.CalculateInterval(_baseInterval);
                await UniTask.Delay(interval);
            }

            await new AbilityCommand(caster, _onDeathAbility).Execute();
        }
    }
}