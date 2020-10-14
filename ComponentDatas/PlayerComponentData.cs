using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct PlayerComponentData : ISharedComponentData, IEquatable<PlayerComponentData>
{

    public Transform cam;
    public float speed;
    public int hashCode;

    public bool Equals(PlayerComponentData other)
    {
        return this.cam == other.cam && this.speed == other.speed;
    }

    public override int GetHashCode()
    {
        return hashCode;
    }
}
