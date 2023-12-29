using System;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Entities;
using UnityEngine;

namespace Targeters
{
    class ClosestTargetInRadius : ITargetProvider
    {
        [SerializeField]
        float _baseRadius = 5;

        public async UniTask<IEntity> GetTarget(IEntity entity)
        {
            var overlaps = new Collider[10];
            IEntity target = null;
            while (target == null)
            {
                float radius = entity.CalculateRadius(_baseRadius);
                int overlapAmount = Physics.OverlapSphereNonAlloc(entity.Origin, radius, overlaps);
                if (overlapAmount > overlaps.Length)
                    Array.Resize(ref overlaps, overlapAmount * 2);

                target = await GetTargetOverlap(entity, overlaps);
            }

            return target;
        }

        async UniTask<IEntity> GetTargetOverlap(IEntity caster, Collider[] overlaps)
        {
            Collider targetCollider = overlaps
                .OrderBy(x => Vector3.Distance(x.transform.position, caster.Origin))
                .FirstOrDefault();

            IEntity target = null;
            while (target == null && targetCollider)
            {
                TimeSpan deltaTime = TimeSpan.FromSeconds(Time.fixedDeltaTime);
                await Task.Delay(deltaTime);
                target = targetCollider.GetComponent<IEntity>();
            }

            return target;
        }
    }
}