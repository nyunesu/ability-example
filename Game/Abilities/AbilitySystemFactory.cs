using System.Collections.Generic;

namespace Abilities
{
    public class AbilitySystemFactory
    {
        public AbilitySystem Create(IEntity caster, List<IAbility> abilities)
        {
            return new AbilitySystem.Builder(caster).WithAbilities(abilities).Build();
        }
    }
}