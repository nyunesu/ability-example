using Cysharp.Threading.Tasks;

public interface IAbility
{
    UniTask Execute(IEntity caster);
}