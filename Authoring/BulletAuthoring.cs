using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class BulletAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField]
    float speed;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var bulletCD = new BulletComponentData();
        bulletCD.speed = this.speed;

        dstManager.AddComponentData(entity, bulletCD);
    }
}
