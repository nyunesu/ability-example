using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace Abilities.Data
{
    abstract class AbilityData : SerializedScriptableObject, IAbility
    {
        public abstract UniTask Cast(IEntity caster);
    }
}