using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player => GameObject.FindWithTag("player");
    [SerializeField] private Vector3 offset;
    [SerializeField] private float distanceOfMouseOffset;
    void Update()
    {
        /*int layerMask = 1 << 6;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray, out hit, 1000, layerMask)) {
            Vector3 target = hit.point;
            target = new Vector3(target.x, player.transform.position.y, target.z);
            playerOffset = target - player.transform.position;
        }
        else
            playerOffset = Vector3.zero;*/
        Vector3 playerOffset =  distanceOfMouseOffset * 2f * new Vector3(Input.mousePosition.x / Screen.width - 0.5f, 0f, Input.mousePosition.y / Screen.height - 0.5f);
        Debug.Log(playerOffset);

        Vector3 position = player.transform.position - new Vector3 (0f, player.transform.position.y, 0f);
        transform.position = position + offset + playerOffset;
    }
}
