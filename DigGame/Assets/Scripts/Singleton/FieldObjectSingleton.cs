using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class FieldObjectSingleton<T> : SerializedMonoBehaviour where T : SerializedMonoBehaviour
{
    public static T instance = null;
    protected virtual void Awake()
    {
        instance = gameObject.GetComponent<T>();
    }
}