using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour {

    public GameObject FirstPersonCharacter;
    public GameObject Wall;
    public GameObject HalfWall;
    public GameObject Lintel;
    public GameObject ComboWall;
    public GameObject TabMenuDisplay;

    private float ClickDelay = 0;

    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        ClickDelay += Time.deltaTime;

        if (Input.GetButton("Fire1") && ClickDelay > 0.1 && TabMenuDisplay.activeSelf == false)
        {
            var ShootScript = FirstPersonCharacter.GetComponent<CubePlacer>(); // set ShootScript to equal the CubePlacer script



            if (ShootScript.DidShootHit == true) //check to see if raycast hits
            {
                
                if (Tiler.GridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY] == 0) //check for empty grid tile before allowing wall to be built
                {
                    //ShootScript.NearestGridPoint(); //find nearest point to place wall
                    if (UIGridLocator.UIEquipText == "Wall")
                    {
                        Instantiate(Wall, new Vector3(CubePlacer.NearestX, 4, CubePlacer.NearestY), Quaternion.identity);
                    }
                    else if (UIGridLocator.UIEquipText == "Half Wall")
                    {
                        Instantiate(HalfWall, new Vector3(CubePlacer.NearestX, 4, CubePlacer.NearestY), Quaternion.identity);
                    }
                    else if (UIGridLocator.UIEquipText == "Lintel")
                    {
                        Instantiate(Lintel, new Vector3(CubePlacer.NearestX, 8, CubePlacer.NearestY), Quaternion.identity);
                    }
                    else if (UIGridLocator.UIEquipText == "Combo Wall")
                    {
                        Instantiate(ComboWall, new Vector3(CubePlacer.NearestX, 0, CubePlacer.NearestY), Quaternion.identity);
                    }

                    Tiler.GridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY] = 1;
                }
            }
            ClickDelay = 0;
        }
    } 
}
