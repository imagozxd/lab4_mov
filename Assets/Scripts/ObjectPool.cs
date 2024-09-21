using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class PoolItem
    {
        public GameObject prefab;
        public int initialSize;
    }

    public List<PoolItem> pools;
    private static Dictionary<GameObject, Queue<GameObject>> poolDictionary;
    private static int maxActiveObjects = 5; 
    private static int currentActiveObjects = 0; 

    private void Awake()
    {
        if (poolDictionary == null)
        {
            poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
        }

        foreach (PoolItem poolItem in pools)
        {
            if (!poolDictionary.ContainsKey(poolItem.prefab))
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < poolItem.initialSize; i++)
                {
                    GameObject obj = Instantiate(poolItem.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(poolItem.prefab, objectPool);
            }
        }
    }

    public static GameObject GetObject(GameObject prefab)
    {
        if (currentActiveObjects >= maxActiveObjects)
        {
            Debug.Log("Se ha alcanzado el límite de objetos activos.");
            return null;
        }

        if (poolDictionary.ContainsKey(prefab))
        {
            GameObject obj = poolDictionary[prefab].Dequeue();
            obj.SetActive(true);
            currentActiveObjects++;
            poolDictionary[prefab].Enqueue(obj);

            ObjectReturner returner = obj.GetComponent<ObjectReturner>();
            if (returner == null)
            {
                returner = obj.AddComponent<ObjectReturner>();
            }
            returner.StartReturnTimer();

            return obj;
        }
        else
        {
            Debug.LogError("Prefab no encontrado en el pool: " + prefab.name);
            return null;
        }
    }

    public static void ReturnObject(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
            currentActiveObjects--;

            ObjectReturner returner = obj.GetComponent<ObjectReturner>();
            if (returner != null)
            {
                returner.StopReturnTimer();
            }
        }
    }
}

public class ObjectReturner : MonoBehaviour
{
    private Coroutine returnCoroutine;

    public void StartReturnTimer()
    {
        returnCoroutine = StartCoroutine(ReturnToPoolAfterTime(5f));
    }

    public void StopReturnTimer()
    {
        if (returnCoroutine != null)
        {
            StopCoroutine(returnCoroutine);
        }
    }

    private IEnumerator ReturnToPoolAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ReturnToPool();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Player"))
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        ObjectPool.ReturnObject(gameObject);
        StopReturnTimer();
    }
}
