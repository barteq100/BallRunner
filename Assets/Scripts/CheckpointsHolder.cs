using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CheckpointsHolder : MonoBehaviour
{
    public Checkpoint[] Checkpoints;
    private int lastUpdateCount = 0;
    private int _id = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying && IsDirty())
        {
            _id = 0;
            lastUpdateCount = Checkpoints.Length;
            UpdateCheckPointsIds();

        }
    }

    void UpdateCheckPointsIds()
    {
        for(int i = 0; i<Checkpoints.Length; i++)
        {
            Checkpoints[i].Id = _id++;
        }
    }

    bool IsDirty()
    {
        return Checkpoints.Length != lastUpdateCount;
    }
}
