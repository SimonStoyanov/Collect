using System;
using UnityEngine;

public interface IKillable
{
    void Kill();
}

public interface IDamageable<T>
{
    void Damage(T damage);
}

public interface IStatus
{
    void Status(Enum @status_enum);
}
