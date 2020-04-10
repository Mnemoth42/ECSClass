using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class SpawnAlso : MonoBehaviour
{
    public GameObject sheepPrefab;
    public int numSheep = 2000;

    Transform[] sheep;

    struct MoveJob: IJobParallelForTransform
    {
        public void Execute(int index, TransformAccess transform)
        {
            transform.position += 0.1f * (transform.rotation * new Vector3(0, 0, 1));
            if (transform.position.z > 50)
            {
                transform.position = new Vector3(transform.position.x, 0, -50);
            }
        }
    }

    MoveJob moveJob;
    JobHandle moveHandle;
    TransformAccessArray transforms;

    // Start is called before the first frame update
    void Start()
    {
        sheep = new Transform[numSheep];
        for (int i = 0; i < numSheep; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            GameObject s = Instantiate(sheepPrefab, pos, Quaternion.identity);
            sheep[i] = s.transform;
        }
        transforms = new TransformAccessArray(sheep);
    }

    private void Update()
    {
        moveJob = new MoveJob { };
        moveHandle = moveJob.Schedule(transforms);
    }

    private void LateUpdate()
    {
        moveHandle.Complete();
    }

    private void OnDestroy()
    {
        transforms.Dispose();
    }
}
