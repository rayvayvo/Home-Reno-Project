using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Debug : MonoBehaviour {

    public Text text;
    public GameObject GridObject;

    void Awake()
    {
        text = GetComponent<Text>();
        text.text = "";
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {
         //text.text = "Debug: (" + CubePlacer.NearestX + " : " + CubePlacer.NearestY + ")" + Tiler.GridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].ToString();
	}
}
