using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player => GameObject.FindWithTag("player");
    [SerializeField] private Vector3 offset;
    void Update()
    {
        Vector3 position = player.transform.position - new Vector3 (0f, player.transform.position.y, 0f);
        transform.position = position + offset;
    }
}
