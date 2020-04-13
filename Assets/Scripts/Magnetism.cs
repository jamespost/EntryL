using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Magnetism needs to make sure that the parent game object has a Sphere Collider that represents its Magnetic Field
[RequireComponent(typeof(SphereCollider))]
public class Magnetism : MonoBehaviour
{
    ///A Class to define magnetic behavior between game objects
    ///
    //Magnetic Strength of the Magnet (in Gauss)
    public float gauss;
    //Reference to the parent objects physical properties
    PhysicalProperties physProp;
    //Magnetism needs to make sure that the parent game object has a Sphere Collider that represents its Magnetic Field
    SphereCollider magneticFieldSphere;
    //A bool to check if a magnetic object is currently attached to a magnet
    public bool isAttached = false;

    private void Start()
    {
        physProp = GetComponent<PhysicalProperties>();
        magneticFieldSphere = GetComponent<SphereCollider>();
        ConfigureSphereCollider();
    }

    //Methods
    //Applies a pulling Force on any Magnetic Game Object within the bounds of magneticFieldSphere
    private void ExertMagneticForce(GameObject g)
    {
        //get the rigidbody component of g
        Rigidbody rb = g.GetComponent<Rigidbody>();
        //face the transform of rb towards the Magnet
        rb.gameObject.transform.LookAt(transform);
        //calculate the distance between the game object and g and store it
        float distance = Vector3.Distance(g.transform.position, transform.position);

        //add force to rb in the direction it is facing
        rb.AddForce(rb.transform.forward * gauss * (distance * distance), ForceMode.Force);
    }

    
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.GetComponent<PhysicalProperties>().isMagnetic)
        {
            //run the ExertMagneticForce method on the gameObject parent of the collision
            ExertMagneticForce(collision.gameObject);

            //debug
            //Debug.Log("There is a magnetic game object within magneticFieldSphere");
        }
    }

    //Sets the radius of the game objects magneticFieldSphere
    private void SetMagneticFieldRadius()
    {
        magneticFieldSphere.radius = gameObject.GetComponentInParent<Rigidbody>().mass;
    }

    //Sets the gauss of the magnet
    private void SetMagnetGaussValue()
    {
        //hard coded debug test
        gauss = .01f;
    }

    //Configures the Sphere Collider for magneticFieldSphere
    private void ConfigureSphereCollider()
    {
        magneticFieldSphere.isTrigger = true;
        SetMagneticFieldRadius();
        SetMagnetGaussValue();
    }    
}
