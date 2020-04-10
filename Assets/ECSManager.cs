using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Random = Unity.Mathematics.Random;

public class ECSManager : MonoBehaviour
{
    EntityManager manager;
    public GameObject sheepPrefab;
    public int numSheep = 15000;
    private void Start()
    {
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(sheepPrefab, settings);

        for (int i = 0; i < numSheep; i++)
        {
            var instance = manager.Instantiate(prefab);
            float3 position = transform.TransformPoint(new float3(UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(0,100), UnityEngine.Random.Range(-50, 50)));
            float2 bubble = new float2(UnityEngine.Random.Range(0.5f, 2), 0);
            manager.SetComponentData(instance, new Translation { Value = position });
            manager.SetComponentData(instance, new Rotation { Value = new quaternion(0, 0, 0, 0) });
            
            
        }
    }
}
