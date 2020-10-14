using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateBefore(typeof(OrderSystemFirst))]
public class InputSystem : ComponentSystem
{
    protected override void OnUpdate()
    {



        Entities.ForEach((ref InputComponentData inputCD) =>
        {
            inputCD.isFireDown = Input.GetButtonDown("Fire1");
            inputCD.horizontal = Input.GetAxis("Horizontal");
            inputCD.vertical = Input.GetAxis("Vertical");

            inputCD.mouseMoveX = Input.GetAxis("Mouse X");
            inputCD.mouseMoveY = Input.GetAxis("Mouse Y");
        });
    }
}
