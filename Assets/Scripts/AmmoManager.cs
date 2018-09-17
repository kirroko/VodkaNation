using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmmoManager : MonoBehaviour
{
    public GameObject AmmoPrefab = null;
    public int poolSize = 100;
    public Queue<Transform> AmmoQueue = new Queue<Transform>();
    private GameObject[] AmmoArray;
    public static AmmoManager AmmoManagerSingleton = null;

    void Awake()
    {
        if(AmmoManagerSingleton != null)
        {
            Destroy(GetComponent<AmmoManager>());
            return;
        }
        AmmoManagerSingleton = this;
        AmmoArray = new GameObject[poolSize];
        for(int i = 0; i <poolSize; i++)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector2.zero, Quaternion.identity) as GameObject;
            Transform OjbTransform = AmmoArray[i].GetComponent<Transform>();
            OjbTransform.parent = GetComponent<Transform>();
            AmmoQueue.Enqueue(OjbTransform);
            AmmoArray[i].SetActive(false);
        }
    }

    public static Transform SpawnAmmo(Vector2 Position, Quaternion Rotation)
    {
        Transform SpawnedAmmo = AmmoManagerSingleton.AmmoQueue.Dequeue();
        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = Position;
        SpawnedAmmo.localRotation = Rotation;
        AmmoManagerSingleton.AmmoQueue.Enqueue(SpawnedAmmo);
        return SpawnedAmmo;
    }
}