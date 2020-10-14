using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct InputComponentData : IComponentData
{
    public bool isFireDown;

    public float horizontal;
    public float vertical;

    public float mouseMoveX;
    public float mouseMoveY;
}
