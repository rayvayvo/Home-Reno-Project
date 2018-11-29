using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPainter : MonoBehaviour {


    public GameObject FirstPersonCharacter;
    public GameObject TabMenuDisplay;
    private float ClickDelay = 0;

    void Start()
    {
    }

    
    void Update()
    {
        ClickDelay += Time.deltaTime;

        if (Input.GetButton("Fire1") && ClickDelay > 0.1 && TabMenuDisplay.activeSelf == false)
        {
            var ShootScript = FirstPersonCharacter.GetComponent<CubePlacer>(); // set ShootScript to equal the CubePlacer script



            if (CubePlacer.DidShootHit == true) //check to see if raycast hits
            {
                
                if (ShootScript.GridHit.collider.ToString().Substring(0, 8) == "WallSide" || ShootScript.GridHit.collider.ToString().Substring(0, 8) == "HalfWall" || ShootScript.GridHit.collider.ToString().Substring(0, 6) == "Lintel" || ShootScript.GridHit.collider.ToString().Substring(0, 5) == "Combo" || ShootScript.GridHit.collider.ToString().Substring(0, 4) == "Grid" || ShootScript.GridHit.collider.ToString().Substring(0, 4) == "Room") 
                {
                    ShootScript.GridHit.transform.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(PaintMenu.LastRed,PaintMenu.LastGreen,PaintMenu.LastBlue, 255);
                }
            }
            ClickDelay = 0;
        }
    }
}
