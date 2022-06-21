using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    // Resources
    public GameObject textContainer;
    public GameObject textPrefab;

    // Create a list of FloatingText objects (see FloatingText.cs)
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        // Manually update UpdateFloatingText() so FloatingText.cs doesn't inherit from MonoBehaviour
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }

    public void Show(string msg, int fontSize, Color colour, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        // Basic settings for the text to be displayed
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = colour;

        // Transfer world space to screen space so we can use it in the UI
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    private FloatingText GetFloatingText()
    {
        // Find a non-active FloatingText object to use
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if(txt == null)
        {
            // Create a new FloatingText object in case there was no non-active one
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            // Add the newly created object to the floatingTexts list to use
            // *new FloatingTexts are never deleted because apparently they were needed*
            floatingTexts.Add(txt);
        }

        return txt;
    }
}