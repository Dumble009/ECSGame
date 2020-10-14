using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class PlayerComponentAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField]
    Transform cam;
    [SerializeField]
    float speed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var playerCD = new PlayerComponentData();
        playerCD.cam = this.cam;
        playerCD.speed = this.speed;
        playerCD.hashCode = GetHashCode();

        dstManager.AddSharedComponentData(entity, playerCD);
    }
}
