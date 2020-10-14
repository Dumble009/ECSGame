using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Extensions;
using Unity.Transforms;

public class BulletComponentSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref BulletComponentData bullet, ref PhysicsVelocity pv, ref LocalToWorld localToWorld)=>{
            pv.Linear = localToWorld.Up * bullet.speed;
        });
    }
}
