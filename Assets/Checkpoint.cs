using Assets.Scripts.Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int Id;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var currentSaveName = PlayerPrefs.GetString(SaveKeys.LAST_SAVE_NAME);
            PlayerPrefs.SetInt(currentSaveName + SaveKeys.SAVE_CHECKPOINT_SUFFIX, Id);
            PlayerPrefs.Save();
        }
    }
}
