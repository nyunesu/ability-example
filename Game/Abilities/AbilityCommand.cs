using Cysharp.Threading.Tasks;

namespace Abilities
{
    class AbilityCommand : ICommand
    {
        readonly IEntity _caster;
        readonly IAbility _ability;
        bool _isExecuting;

        public AbilityCommand(IEntity caster, IAbility ability)
        {
            _caster = caster;
            _ability = ability;
        }

        public async UniTask Execute()
        {
            if (_isExecuting)
                return;

            _isExecuting = true;
            await _ability.Cast(_caster);
            _isExecuting = false;
        }
    }
}