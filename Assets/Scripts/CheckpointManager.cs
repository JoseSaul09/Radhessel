using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;
    private bool isFirstCheckpointSet = false;

    private void Start()
    {
        lastCheckpointPosition = transform.position;
    }
    public void UpdateCheckpoint(Vector3 newCheckpointPosition)
    {
        lastCheckpointPosition = newCheckpointPosition;
        isFirstCheckpointSet = true;
    }
    public Vector3 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }
    public bool IsFirstCheckpointSet()
    {
        return isFirstCheckpointSet;
    }
}
