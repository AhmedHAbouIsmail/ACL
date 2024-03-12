using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera camera1;
    [SerializeField] Camera camera2;
    // Start is called before the first frame update
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        camera1.transform.position = new Vector3(camera1.transform.position.x, camera1.transform.position.y,player.transform.position.z-6);
        camera2.transform.position = new Vector3(camera2.transform.position.x, camera2.transform.position.y, player.transform.position.z);
        if (Input.GetKeyDown(KeyCode.C))
        {
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }
}
