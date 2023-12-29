using System.Collections.Generic;

namespace Abilities
{
    public class AbilitySystem
    {
        List<ICommand> _commands = new();

        AbilitySystem() { }

        public void Cast()
        {
            foreach (ICommand command in _commands)
                command.Execute();
        }

        void Add(ICommand command)
        {
            _commands.Add(command);
        }

        public class Builder
        {
            IEntity _caster;
            List<IAbility> _abilities;

            public Builder(IEntity caster)
            {
                _caster = caster;
            }

            public Builder WithAbilities(List<IAbility> abilities)
            {
                _abilities = abilities;
                return this;
            }

            public AbilitySystem Build()
            {
                AbilitySystem system = new();
                foreach (IAbility ability in _abilities)
                    system.Add(new AbilityCommand(_caster, ability));

                return system;
            }
        }
    }
}