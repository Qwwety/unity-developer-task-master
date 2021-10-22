using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ObjectPoolerStatic : MonoBehaviour
{
    public static ObjectPoolerStatic Instance;
    private void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    private class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int PoolSize;
    }
    [SerializeField] private List<Pool> Pools; // Лисст Пулов с именем Пул
    private Dictionary<string, Queue<GameObject>> PoolDictionary;// Словарь с ключеом типа string и хранимым обектом  Queue с типом GameObject

    private void Start()// Заполнение пула определеными объектами
    {
        // Присвоение переменой  PoolDictionary значения  Dictionary
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objects = new Queue<GameObject>();// objects Переменая которая хранит в себе  обектом  Queue с типом GameObject
            for (int i = 0; i < pool.PoolSize; i++) // Проверка-пока перемпная размер пула (класс,16 строка), не зпполнилась 
            {
                GameObject @object = Instantiate(pool.Prefab);//  @object- переменая которая цхранит в себе спавн определнного объекта(определяется в классе,16 строка )
                @object.SetActive(false);
                objects.Enqueue(@object); // постанока объекта objects в конец очереди пула
            }
            PoolDictionary.Add(pool.Tag, objects); // добавление в словарь объекта с опеределными тегом 
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotatrion) // Определение объекта из пула для Спавна
    {
        if (!PoolDictionary.ContainsKey(tag)) // Проверка на существование Пула по тегу
        {
            Debug.LogWarning("😂🔫" + "Такого тега(" + tag + ") нет");
            return null;
        }

        GameObject objectToSpawn = PoolDictionary[tag].Dequeue(); // Доставание объекта из очереди по тегу 
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotatrion;

        InterfacePooledObject pooledObject = objectToSpawn.GetComponent<InterfacePooledObject>(); // экземпляр Интерфейс 

        if (pooledObject != null)  // проверка не пустой ли Пул 
        {
            pooledObject.OnSpawn(); // спавн- лежит в интерфейсе 
        }

        PoolDictionary[tag].Enqueue(objectToSpawn);// Занесене заспавленых объектов в очредь, тобы после оканчания снова спавниитьт в порядке
        Debug.Log("objectToSpawn");
        return objectToSpawn; // объект кторый нужно заспавнить

    }

    //private void FixedUpdate()
    //{
    //    if (Input.GetMouseButton(1))
    //    {
    //        SpawnFromPool("Bullet", transform.position, transform.rotation);
    //        Debug.Log("Bullet");
    //    }

    //}

   
}

// Класс который хронит в себе список параметров для пула

