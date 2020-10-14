using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

[Serializable]
public struct GunComponentData  : ISharedComponentData, IEquatable<GunComponentData>
{
    public float muzzleX, muzzleY, muzzleZ;
    public Entity bulletPrefab;
    public int hashCode;

    public bool Equals(GunComponentData other)
    {
        return muzzleX == other.muzzleX && muzzleY == other.muzzleY && muzzleZ == other.muzzleZ && bulletPrefab.GetHashCode() == other.GetHashCode();
    }

    public override int GetHashCode()
    {
        return hashCode;
    }
}
