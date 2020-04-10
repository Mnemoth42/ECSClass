using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;
public class LargeCubeSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobHandle = Entities
                        .WithName("MoveSystem")
                        .ForEach((ref Translation position, ref Rotation rotation, ref LargeCubeData cubeData) =>
                                 {
                                     position.Value -= 0.01f * math.up();
                                 })
                        .Schedule(inputDeps);
        return jobHandle;
    }
}
