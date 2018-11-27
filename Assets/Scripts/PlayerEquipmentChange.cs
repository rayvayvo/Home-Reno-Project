using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentChange : MonoBehaviour {

    public static string CurrentEquip;
    public GameObject Painter;
    public GameObject WallBuilder;
    public GameObject HeldObject;
    public GameObject WallDestroyer;
    public GameObject PainterIcon;
    public GameObject WallBuilderIcon;
    public GameObject BuyIcon;
    public GameObject WallDestroyerIcon;
    public Sprite EquipSlotLogoHighlighted;
    public Sprite EquipSlotLogo;

    
    void Start () {
        CurrentEquip = "Painter";
        PainterIcon.GetComponent<Image>().sprite = EquipSlotLogoHighlighted;
    }
	
	void Update () {
        ChangeEquip();
	}


    public void ChangeEquip()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            //On Input turn this one ON and others OFF
        {
            CurrentEquip = "Painter";
            Painter.SetActive(true);
            WallBuilder.SetActive(false);
            HeldObject.SetActive(false);
            WallDestroyer.SetActive(false);
            BuyIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            WallBuilderIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            WallDestroyerIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            PainterIcon.GetComponent<Image>().sprite = EquipSlotLogoHighlighted;

            //You can also add code for sound, particles, etc.
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            CurrentEquip = "WallBuilder";
            WallBuilder.SetActive(true);
            Painter.SetActive(false);
            HeldObject.SetActive(false);
            WallDestroyer.SetActive(false);
            BuyIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            WallBuilderIcon.GetComponent<Image>().sprite = EquipSlotLogoHighlighted;
            WallDestroyerIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            PainterIcon.GetComponent<Image>().sprite = EquipSlotLogo;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            CurrentEquip = "WallDestroyer";
            WallDestroyer.SetActive(true);
            Painter.SetActive(false);
            WallBuilder.SetActive(false);
            HeldObject.SetActive(false);
            BuyIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            WallBuilderIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            WallDestroyerIcon.GetComponent<Image>().sprite = EquipSlotLogoHighlighted;
            PainterIcon.GetComponent<Image>().sprite = EquipSlotLogo;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            CurrentEquip = "HeldObject";
            HeldObject.SetActive(true);
            WallBuilder.SetActive(false);
            WallDestroyer.SetActive(false);
            Painter.SetActive(false);
            BuyIcon.GetComponent<Image>().sprite = EquipSlotLogoHighlighted;
            WallBuilderIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            WallDestroyerIcon.GetComponent<Image>().sprite = EquipSlotLogo;
            PainterIcon.GetComponent<Image>().sprite = EquipSlotLogo;

        }
    }
 }