using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    // References
    public GameObject go;

    // Resources
    public Text txt;
    public Vector3 motion;
    
    // Logic
    public bool active;
    public float duration;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        // Don't update when there is no active text
        if (!active)
            return;
        
        // Neat trick to tell if the duration was exceeded
        if (Time.time - lastShown > duration)
            Hide();

        go.transform.position += motion * Time.deltaTime;
    }
}
