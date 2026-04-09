using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamerManager : MonoBehaviour
{
    public Camera currentCamera;
    public Camera[] cameras;

    void Start()
    {
        ActivateCamera(currentCamera);
    }

    void Update()
    {
        // If current camera is destroyed or missing
        if (currentCamera == null)
        {
            SwitchToNextCamera();
        }
        if (cameras[0] == null)
        { 
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void SwitchToNextCamera()
    {
        foreach (Camera cam in cameras)
        {
            if (cam != null)
            {
                ActivateCamera(cam);
                break;
            }
        }
    }

    void ActivateCamera(Camera cam)
    {
        foreach (Camera c in cameras)
        {
            if (c != null)
                c.gameObject.SetActive(false);
        }

        cam.gameObject.SetActive(true);
        currentCamera = cam;
    }
}
