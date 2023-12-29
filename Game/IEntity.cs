using UnityEngine;

public interface IEntity
{
    Vector3 Origin { get; }

    bool IsAlive();

    void TakeDamage(float damage);
}