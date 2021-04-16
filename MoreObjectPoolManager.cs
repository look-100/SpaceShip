using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoreObjectPoolManager
{
    private GameObject objPre;
    private int listSize;
    private bool isAutoGrow;
    private GameObject parentPoint;
    private List<GameObject> listObj;

    public MoreObjectPoolManager(GameObject _parentPoint, GameObject _obj, int _listSize, bool _isAutoGrow)
    {
        parentPoint = _parentPoint;
        objPre = _obj;
        listSize = _listSize;
        isAutoGrow = _isAutoGrow;
        listObj = new List<GameObject>();
        for (int i = 0; i < listSize; i++)
        {
            GameObject obj = GameObject.Instantiate(objPre);
            obj.transform.parent = parentPoint.transform;
            obj.SetActive(false);
            listObj.Add(obj);
        }
    }

    public GameObject GetGameObject()
    {
        for (int i = 0; i < listObj.Count; i++)
        {
            if (!listObj[i].activeSelf)
            {
                listObj[i].SetActive(true);
                if (listObj[i].GetComponent<Collider2D>() != null)
                    listObj[i].GetComponent<Collider2D>().enabled = true;
                return listObj[i];
            }
        }

        if (isAutoGrow)
        {
            GameObject obj = GameObject.Instantiate(objPre);
            obj.SetActive(true);
            obj.transform.parent = parentPoint.transform;
            listObj.Add(obj);
            return obj;
        }

        Debug.LogError("GetGameObject is null.");
        return null;
    }
}

