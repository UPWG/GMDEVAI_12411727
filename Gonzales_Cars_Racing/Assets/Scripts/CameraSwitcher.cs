using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;   // Assign 4 cameras in Inspector
    public float switchTime = 3f;

    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        ActivateCamera(0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            timer = 0f;
            currentIndex = (currentIndex + 1) % cameras.Length;
            ActivateCamera(currentIndex);
        }
    }

    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }
}