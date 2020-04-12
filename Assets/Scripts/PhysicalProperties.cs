using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalProperties : MonoBehaviour
{
    ///A Class that defines basic physical properties of a Game Object
    ///

    //Properties (should be publicly accessible as these define how Game Objects can interact with each other)
    public bool isPermanentMagnet;
    public bool isMagnetic;


    private void Start()
    {
        CheckMagnet();
    }

    //Methods
    //A Method to make a Game Object a Magnet
    private void MakeMagnet()
    {
        //GameObject magnetObject = new GameObject();
        //Adds the Magnetism Componenent to the Game Object
        gameObject.AddComponent<Magnetism>();

    }
    //A method to check if a Game Object should be a Magnet
    private void CheckMagnet()
    {
        if (isPermanentMagnet)
        {
            MakeMagnet();
        }
    }
    

}
