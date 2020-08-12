using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Drop : MonoBehaviour
{
    public UnityAction OnDrop;
    private void OnTriggerEnter(Collider other)
    {
        OnDrop?.Invoke();
    }
}
