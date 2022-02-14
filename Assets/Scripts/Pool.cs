using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }
    private List<T> poolList;


    public Pool(T prefab , int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;

        this.CreatePool(count);
    }


    private void CreatePool(int count)
    {
        this.poolList = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        T createdObject = Object.Instantiate(this.prefab, this.container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.poolList.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var elem in poolList)
        {
            if (!elem.gameObject.activeInHierarchy)
            {
                element = elem;
                elem.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out T element))
        {
            return element;
        }
        if (this.autoExpand)
        {
            return this.CreateObject(true);
        }
        throw new System.Exception($"There is no element in pool of type {typeof(T)}");
    }
}
