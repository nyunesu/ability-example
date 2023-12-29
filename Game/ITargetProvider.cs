using Cysharp.Threading.Tasks;

public interface ITargetProvider
{
    UniTask<IEntity> GetTarget(IEntity entity);
}