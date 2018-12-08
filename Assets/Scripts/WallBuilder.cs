using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileData;

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
            TabMenu theData = GameObject.FindWithTag("TileData").GetComponent<TabMenu>();

            if (theData.TileData.gridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY].contents == "Empty") //check for empty grid tile before allowing wall to be built
                {
                    
                    if (UIGridLocator.UIEquipText == "Wall")
                    {
                        Instantiate(Wall, new Vector3((int)CubePlacer.NearestX, 4, (int)CubePlacer.NearestY), Quaternion.identity);
                    }
                    else if (UIGridLocator.UIEquipText == "Half Wall")
                    {
                        Instantiate(HalfWall, new Vector3((int)CubePlacer.NearestX, 4, (int)CubePlacer.NearestY), Quaternion.identity);
                    }
                    else if (UIGridLocator.UIEquipText == "Lintel")
                    {
                        Instantiate(Lintel, new Vector3((int)CubePlacer.NearestX, 8, (int)CubePlacer.NearestY), Quaternion.identity);
                    }
                    else if (UIGridLocator.UIEquipText == "Combo Wall")
                    {
                        Instantiate(ComboWall, new Vector3((int)CubePlacer.NearestX, 0, (int)CubePlacer.NearestY), Quaternion.identity);
                    }

                theData.TileData.gridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].contents = UIGridLocator.UIEquipText;
                for (int x = 0; x < 3; x++)
                {
                    theData.TileData.gridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].faceN[x] = 255;
                    theData.TileData.gridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].faceS[x] = 255;
                    theData.TileData.gridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].faceE[x] = 255;
                    theData.TileData.gridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].faceW[x] = 255;

                    if(UIGridLocator.UIEquipText == "Half Wall")
                    {
                        theData.TileData.gridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].faceT[x] = 255;
                    }
                    else if (UIGridLocator.UIEquipText == "Lintel")
                    {
                        theData.TileData.gridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY].faceB[x] = 255;
                    }

                }

            }
            ClickDelay = 0;
        }
    } 
}
