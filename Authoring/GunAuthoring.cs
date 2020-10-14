using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class GunAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField]
    Transform muzzle;
    [SerializeField]
    GameObject bulletPrefab;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var gunCD = new GunComponentData();
        gunCD.muzzleX = muzzle.localPosition.x;
        gunCD.muzzleY = muzzle.localPosition.y;
        gunCD.muzzleZ = muzzle.localPosition.z;

        gunCD.hashCode = this.GetHashCode();

        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var entityBullet = GameObjectConversionUtility.ConvertGameObjectHierarchy(bulletPrefab, settings);

        gunCD.bulletPrefab = entityBullet;

        dstManager.AddSharedComponentData(entity, gunCD);
    }
}
