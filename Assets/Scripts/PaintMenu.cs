using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintMenu : MonoBehaviour {

    public Text SliderRedText;
    public Text SliderBlueText;
    public Text SliderGreenText;
    public Slider SliderRed;
    public Slider SliderGreen;
    public Slider SliderBlue;
    public Image ColourSample;
    public static byte LastRed;
    public static byte LastGreen;
    public static byte LastBlue;
    public Image UIEquipimage;
    public Text UIEquipinfo;

    // Use this for initialization
    void Start () {

        if (LastRed > 0 || LastGreen > 0 || LastBlue > 0)
        {
            SliderRed.value = LastRed;
            SliderGreen.value = LastGreen;
            SliderBlue.value = LastBlue;
        }
    }
	
	// Update is called once per frame
	void Update () {
        SliderRedText.text = SliderRed.value.ToString();
        SliderGreenText.text = SliderGreen.value.ToString();
        SliderBlueText.text = SliderBlue.value.ToString();
        LastRed = (byte)SliderRed.value;
        LastBlue = (byte)SliderBlue.value;
        LastGreen = (byte)SliderGreen.value;

        ColourSample.color = new Color32(LastRed, LastGreen, LastBlue, 255);
        UIEquipimage.color = new Color32(LastRed, LastGreen, LastBlue, 255);
        if (LastRed + LastGreen + LastBlue > 450 || LastRed + LastGreen + LastBlue < 300)
        {
            UIEquipinfo.color = new Color32((byte)(255 - LastRed), (byte)(255 - LastGreen), (byte)(255 - LastBlue), 255);
        }
        else
        {
            UIEquipinfo.color = Color.black;
        }
        
    }
}
