using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ObjectPoolInfo
{
    public GameObject objPre;
    public int objPoolSize;
    public bool isAutoGrow;
}

public class MoreObjectPool : MonoBehaviour
{
    public static MoreObjectPool instance;
    public ObjectPoolInfo[] objectPoolInfos;

    public Dictionary<string, MoreObjectPoolManager> objectPools;
    void Awake()
    {
        instance = this;
        objectPools = new Dictionary<string, MoreObjectPoolManager>();
        OnInit();
    }

    public void OnInit()
    {
        for (int i = 0; i < objectPoolInfos.Length; i++)
        {
            if (objectPools.ContainsKey(objectPoolInfos[i].objPre.name))
            {
                Debug.Log("对象已存在");
            }
            else
            {
                MoreObjectPoolManager morePool = new MoreObjectPoolManager(this.gameObject, objectPoolInfos[i].objPre, objectPoolInfos[i].objPoolSize, objectPoolInfos[i].isAutoGrow);
                objectPools.Add(objectPoolInfos[i].objPre.name, morePool);
            }
        }
    }

    public GameObject GetGameObjectPool(string objName)
    {
        return objectPools[objName].GetGameObject();
    }

    public void ReturnPool(GameObject _go)
    {
        // if (_go.transform.parent != null)
        // {
        //     _go.transform.parent.gameObject.SetActive(false);
        // }
        // else
        // {
        _go.SetActive(false);
        //go.SetActive(false);
        //objectPools.Add(go.name, objectPoolInfos[]);
    }
}
