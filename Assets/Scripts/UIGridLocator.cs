using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIGridLocator : MonoBehaviour {

    public static string UIEquipText;
    Text text;


    void Awake()
    {
        text = GetComponent<Text>();
        UIEquipText = "Wall";
    }


    void Update()
    {

        text.text = UIEquipText;

    }

}
