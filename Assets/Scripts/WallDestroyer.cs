using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileData;

public class WallDestroyer : MonoBehaviour {

    public GameObject FirstPersonCharacter;
    private float ClickDelay = 0; 
    // Use this for initialization

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ClickDelay += Time.deltaTime;

        if (Input.GetButton("Fire1") && ClickDelay > 0.1)
        {
            var ShootScript = FirstPersonCharacter.GetComponent<CubePlacer>(); // set ShootScript to equal the CubePlacer script
            var theData = GameObject.FindWithTag("TileData").GetComponent<TabMenu>();

            if (CubePlacer.DidShootHit == true && CubePlacer.HighlighterTarget != "G") //check to see if raycast hits
            {

                if (theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].contents != "Empty" )
                {
                    // *** need to fix code to get ceiling destroy fixed. or not, not sure if I want to allow single tile destruction yet.
                    if (CubePlacer.HighlighterTarget == "R")
                    {
                        Destroy(ShootScript.GridHit.collider.transform.gameObject);
                    }
                    else
                    {
                        Destroy(ShootScript.GridHit.collider.transform.parent.gameObject);
                    }
                    theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].contents = "Empty";
                }
            }
            ClickDelay = 0;
        }
    }
}
