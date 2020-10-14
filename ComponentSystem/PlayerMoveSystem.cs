using System.Numerics;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class PlayerMoveSystem : ComponentSystem
{
    float deltaTime = 0;
    protected override void OnUpdate()
    {
        deltaTime = UnityEngine.Time.deltaTime;
        Entities.ForEach((PlayerComponentData playerCD, ref Translation position, ref Rotation rotation, ref InputComponentData input, ref LocalToWorld localToWorld) =>
        {
            var move = localToWorld.Right * input.horizontal + localToWorld.Forward * input.vertical;
            move *= deltaTime;
            position.Value += move;

            playerCD.cam.Translate(move.x, move.y, move.z);

            var yrot = quaternion.RotateY(input.mouseMoveX * 2 * 3.14159067f / 360);

            var tmpRot = math.mul(rotation.Value, yrot);

            rotation.Value = tmpRot;

            var euler = UnityEngine.Vector3.zero;
            euler.y = input.mouseMoveX;

            var q = UnityEngine.Quaternion.identity;
            q.eulerAngles = euler;

            playerCD.cam.rotation = playerCD.cam.rotation * q;
        });
    }
}
