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

                if (Tiler.GridData[(int)CubePlacer.NearestParentX, (int)CubePlacer.NearestParentY] == 0) //check for empty grid tile before allowing wall to be built
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

                    Tiler.GridData[(int)CubePlacer.NearestX, (int)CubePlacer.NearestY] = 1;
                }
            ClickDelay = 0;
        }
    } 
}
