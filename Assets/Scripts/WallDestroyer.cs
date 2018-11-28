using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            if (CubePlacer.DidShootHit == true && CubePlacer.HighlighterTarget != "G") //check to see if raycast hits
            {
               
                if (Tiler.GridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY] == 1)
                {
                    //ShootScript.NearestGridPoint(); //find nearest point to place wall
                    Destroy(ShootScript.GridHit.collider.transform.parent.gameObject);

                    Tiler.GridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY] = 0;
                }
            }
            ClickDelay = 0;
        }
    }
}
