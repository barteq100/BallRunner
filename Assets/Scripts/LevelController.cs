using Assets.Scripts.Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public DefaultNamespace.CameraFollow CameraFollow;
    public GameObject BallPrefab;
    public CheckpointsHolder CheckpointsHolder;
    public Drop Drop;

    private Save _currentSave;
    private GameObject Ball;

    void Awake()
    {
        _currentSave = SaveUtils.GetLatestSave();
        SubscribeToCheckpoints();
        Drop.OnDrop += Reload;
    }

    private void Start()
    {
        var checkPoint = CheckpointsHolder.GetCheckpoint(_currentSave.CheckPoint);
        var transform = checkPoint.transform;
        Ball = GameObject.Instantiate(BallPrefab, transform.position, transform.rotation);
        CameraFollow.Target = Ball.transform;
    }

    void SubscribeToCheckpoints()
    {
        foreach(var checkpoint in CheckpointsHolder.Checkpoints)
        {
            checkpoint.OnCheckPointCrossed += OnCheckPointCrossed;
        }
    }

    void OnCheckPointCrossed(Checkpoint checkpoint)
    {
        _currentSave.CheckPoint = checkpoint.Id;
        _currentSave = _currentSave.Store();
    }

    void Reload()
    {
        SceneManager.LoadScene(_currentSave.LevelName);
    }

}
