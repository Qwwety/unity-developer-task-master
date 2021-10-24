using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolDynamic : MonoBehaviour
{
    [SerializeField] private int PoolSize;
    [SerializeField] private int Scale = 3;
    [SerializeField] private GameObject GameObject;
    

    private List<GameObject> ObjectList;
    private Vector3 onScreenPosition;
    private Vector3 newPosition;
    private Vector3 worldCoordinates;

    public static ObjectPoolDynamic Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ObjectList = new List<GameObject>();
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject @object = Instantiate(GameObject);
            @object.SetActive(false);
            ObjectList.Add(@object);
        }
    }

    public GameObject SpawnFromPool(Vector3 Position, Quaternion Rotatrion,float Scale)
    {
        for (int i = 0; i < ObjectList.Count; i++)
        {
            if (!ObjectList[i].activeInHierarchy)
            {
                ObjectList[i].transform.position = Position;
                ObjectList[i].transform.rotation = Rotatrion;
                ObjectList[i].transform.localScale = new Vector3(Scale, Scale, Scale);
                ObjectList[i].SetActive(true);
                return ObjectList[i];
            }
        }
        GameObject @object = Instantiate(GameObject);
        @object.transform.position = Position;
        @object.transform.rotation = Rotatrion;
        @object.transform.localScale =new Vector3(Scale, Scale, Scale);
        @object.SetActive(true);
        ObjectList.Add(@object);
        return @object;
    }

    public void Spawn()
    {
        if (!GameObject.FindWithTag("Asteroid"))
        {
            for (int i = 0; i < PoolSize; i++)
            {
                ObjectPoolDynamic.Instance.SpawnFromPool(SetSpawnPosition(), transform.rotation, Scale);
            }
            Scale = Random.Range(1, 4);
            PoolSize += 1;
        }
    }

    private Vector3 SetSpawnPosition()
    {
        onScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        newPosition = onScreenPosition;

        newPosition.x = Screen.width;
        newPosition.y = Screen.height;

        worldCoordinates = Camera.main.ScreenToWorldPoint(newPosition);
        worldCoordinates.x = Random.Range(-worldCoordinates.x-2, worldCoordinates.x+2);

        worldCoordinates.z += 2;

        float ZSite = Random.Range(-1, 1);

        if (ZSite == -1)
        {
            worldCoordinates.z *= -1;
        }

        return new Vector3(worldCoordinates.x, 0, worldCoordinates.z);
    }

}
