using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public GameObject[] cameras;
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
                

    }
    public void activateCamera(int number, bool status)
    {
        cameras[number].SetActive(status);
    }
}
