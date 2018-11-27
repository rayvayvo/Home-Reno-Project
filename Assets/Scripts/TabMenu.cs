using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabMenu : MonoBehaviour {

    public GameObject TabMenuDisplay;
    public GameObject FPSController;
    public GameObject PaintMenu;
    public GameObject BuildMenu;
    public GameObject BuyMenu;
    public Button PaintButton;
    public Button BuildButton;
    public Button BuyButton;
    public Text reticle;

    // Use this for initialization
    void Start () {
        PaintButton.onClick.AddListener(PaintButtonClick);
        BuildButton.onClick.AddListener(BuildButtonClick);
        BuyButton.onClick.AddListener(BuyButtonClick);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (TabMenuDisplay.activeSelf == false)
            { 
                TabMenuDisplay.SetActive(true);
                FPSController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
                reticle.text = "";

                if (PlayerEquipmentChange.CurrentEquip == "Painter")
                {
                    PaintMenu.SetActive(true);
                    BuildMenu.SetActive(false);
                    BuyMenu.SetActive(false);
                }
                if (PlayerEquipmentChange.CurrentEquip == "WallBuilder" || PlayerEquipmentChange.CurrentEquip == "WallDestroyer")
                {
                    PaintMenu.SetActive(false);
                    BuildMenu.SetActive(true);
                    BuyMenu.SetActive(false);
                }
                if (PlayerEquipmentChange.CurrentEquip == "HeldObject")
                {
                    PaintMenu.SetActive(false);
                    BuildMenu.SetActive(false);
                    BuyMenu.SetActive(true);
                }
            }
            else
            {
                TabMenuDisplay.SetActive(false);
                FPSController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = true;
                PaintMenu.SetActive(false);
                BuildMenu.SetActive(false);
                BuyMenu.SetActive(false);
                reticle.text = "+";
            } 

        }
    }

    void PaintButtonClick()
    {
        PaintMenu.SetActive(true);
        BuildMenu.SetActive(false);
        BuyMenu.SetActive(false);
    }

    void BuildButtonClick()
    {
        PaintMenu.SetActive(false);
        BuildMenu.SetActive(true);
        BuyMenu.SetActive(false);
    }

    void BuyButtonClick()
    {
        PaintMenu.SetActive(false);
        BuildMenu.SetActive(false);
        BuyMenu.SetActive(true);
    }

}
