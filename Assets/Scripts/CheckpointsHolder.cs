using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class CheckpointsHolder : MonoBehaviour
{
    [SerializeField] private Checkpoint[] _checkpoints;
    public Checkpoint[] Checkpoints => _checkpoints;
    private int lastUpdateCount = 0;
    private int _id = 0;
    
    public Checkpoint GetCheckpoint(int id)
    {
        return _checkpoints.FirstOrDefault(x => x.Id == id);
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying && IsDirty())
        {
            _id = 0;
            lastUpdateCount = _checkpoints.Length;
          //  UpdateCheckPointsIds();
        }
    }

    void UpdateCheckPointsIds()
    {
        for(int i = 0; i< _checkpoints.Length; i++)
        {
            _checkpoints[i].Id = _id++;
        }
    }

    bool IsDirty()
    {
        return _checkpoints.Length != lastUpdateCount;
    }
}
