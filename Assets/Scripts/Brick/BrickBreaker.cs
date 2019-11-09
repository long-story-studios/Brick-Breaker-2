using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The point of this script is to turn on kinematics on cubes that were clicked on
//So the way this works is that when the player clicks on the brick, it creates a raycast that finds the point of contact from the camera to the brick

public class BrickBreaker : MonoBehaviour
{
    [SerializeField] LayerMask clickMask;
    [SerializeField] float radius = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 clickPosition = -Vector3.one;   //Just a default value

            //Raycasting using colliders
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f, clickMask))
            {
                clickPosition = hit.point;

                //Now create a sphere collider here grab all the cubes there
                Collider[] colliders = Physics.OverlapSphere(clickPosition, radius, clickMask);

                //Play sound
                GetComponent<AudioSource>().Play();
                foreach(Collider collider in colliders)
                {
                    collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //Push this dude
                    collider.gameObject.GetComponent<Rigidbody>().AddExplosionForce(500.0f, clickPosition, 500.0f);
                    collider.transform.parent = null;
                    collider.gameObject.layer = 10;
                }
                
            }



            Debug.Log(clickPosition);
        }
    }

    
}
