using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    [SerializeField] int cameraActive;
    // Start is called before the first frame update
    void Start()
    {
        activateCamera(0, true);
        cameraActive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("APRETO F1");
            Debug.Log(cameraActive);

            activateCamera(0, true);
            activateCamera(1, false);
            cameraActive = 0;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("APRETO F2");
            Debug.Log(cameraActive);

            activateCamera(0, false);
            activateCamera(1, true);
            cameraActive = 1;
        }

    }
    private void activateCamera(int number, bool status)
    {
        cameras[number].SetActive(status);
    }
}
