using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = FindFirstObjectByType<CheckpointManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            checkpointManager.UpdateCheckpoint(transform.position);
            Debug.Log("Checkpoint alcanzado: " + transform.position);
            Destroy(gameObject);
        }
    }
}
