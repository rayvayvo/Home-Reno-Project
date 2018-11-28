using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Debug : MonoBehaviour {
    
    public static Text text;
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
        if (CubePlacer.DidShootHit == true)
        {            
        text.text = "Debug: (" + CubePlacer.NearestX + " : " + CubePlacer.NearestY + ")" + Tiler.GridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].ToString() + "{" + CubePlacer.HighlighterSurface + "}";
        }
        if (CubePlacer.DidShootHit == true && CubePlacer.HighlighterTarget == "W")
        {
            text.text = "Debug: (" + CubePlacer.NearestX + " : " + CubePlacer.NearestY + ")" + "<" + CubePlacer.NearestParentX + " : " + CubePlacer.NearestParentY + ">" + " |" + Tiler.GridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].ToString() + ":" + Tiler.GridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].ToString() + "| " + "{" + CubePlacer.HighlighterSurface + "}";
        }
    }
}
