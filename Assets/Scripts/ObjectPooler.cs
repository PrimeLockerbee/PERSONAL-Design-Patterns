using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class ObjectPoolEnemy
{
  public GameObject objectToPool;
  public int amountToPool;
  public bool shouldExpand;
}

public class ObjectPooler : MonoBehaviour 
{
  public static ObjectPooler SharedInstance;
  public List<ObjectPoolEnemy> enemiesToPool;
  public List<GameObject> pooledObjects;

	void Awake() 
    {
		SharedInstance = this;
	}

  void Start () 
  {
    pooledObjects = new List<GameObject>();
    foreach (ObjectPoolEnemy item in enemiesToPool) 
    {
      //Instantiates pooled objects
      for (int i = 0; i < item.amountToPool; i++) 
      {
        GameObject obj = (GameObject)Instantiate(item.objectToPool);
        obj.SetActive(false);
        pooledObjects.Add(obj);
      }
    }
  }
	
  public GameObject GetPooledObject(string tag) 
  {
    for (int i = 0; i < pooledObjects.Count; i++) 
    {
      if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) 
      {
        return pooledObjects[i];
      }
    }
    foreach (ObjectPoolEnemy enemy in enemiesToPool) 
    {
      if (enemy.objectToPool.tag == tag) 
      {
        //Allows the pool to expand if needed
        if (enemy.shouldExpand) 
        {
          GameObject obj = (GameObject)Instantiate(enemy.objectToPool);
          obj.SetActive(false);
          pooledObjects.Add(obj);
          return obj;
        }
      }
    }
    return null;
  }
}
