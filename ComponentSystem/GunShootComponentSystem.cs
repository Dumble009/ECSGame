using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateAfter(typeof(OrderSystemFirst))]
public class GunShootComponentSystem : ComponentSystem {
    protected override void OnUpdate()
    {
        Entities.ForEach((GunComponentData gun, ref Translation position, ref Rotation rot, ref InputComponentData input, ref LocalToWorld localToWorld) =>
        {
            if (input.isFireDown)
            {
                var muzzleF3 = new float3(gun.muzzleX, gun.muzzleY, gun.muzzleZ);
                var m = math.rotate(math.quaternion(localToWorld.Value).value, muzzleF3);

                var bulletPosition = new Translation();

                bulletPosition.Value = localToWorld.Position + m;

                var bullet = EntityManager.Instantiate(gun.bulletPrefab);

                EntityManager.SetComponentData(bullet, bulletPosition);

                var bulletRotation = rot;

                bulletRotation.Value = quaternion.LookRotation(-localToWorld.Up, localToWorld.Forward);
                
                EntityManager.SetComponentData(bullet, bulletRotation);
            }
        });
       
    }
}
