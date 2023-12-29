using Cysharp.Threading.Tasks;

public interface IAbility
{
    UniTask Cast(IEntity caster);
}