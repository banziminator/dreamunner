using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite oldSprite;

    private bool isOn = false;

    private void Start()
    {
        // Load the saved state of the button
        isOn = PlayerPrefs.GetInt("MusicButtonState", 0) == 1;

        // Update the button sprite based on the loaded state
        if (isOn)
        {
            GetComponent<Image>().sprite = newSprite;
        }
        else
        {
            GetComponent<Image>().sprite = oldSprite;
        }
    }

    public void OnClick()
    {
        isOn = !isOn;

        if (isOn)
        {
            GetComponent<Image>().sprite = newSprite;
        }
        else
        {
            GetComponent<Image>().sprite = oldSprite;
        }

        // Save the current state of the button
        PlayerPrefs.SetInt("MusicButtonState", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
