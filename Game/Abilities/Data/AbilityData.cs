using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace Abilities.Data
{
    abstract class AbilityData : SerializedScriptableObject, IAbility
    {
        public abstract UniTask Execute(IEntity caster);
    }
}