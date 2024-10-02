using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{
    private BoxCollider2D checkPointCollider;
    [SerializeField] private GameObject savedCheckPoint;

    void Awake()
    {
        checkPointCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            checkPointCollider.enabled = false;
            other.gameObject.GetComponent<PlayerMovement>().currentSpawnPoint = transform;
            savedCheckPoint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            savedCheckPoint.SetActive(false);
        }
    }
}
