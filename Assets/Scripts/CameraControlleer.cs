using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlleer : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public Transform Target;
    private float mouseX;
    public Transform Obstruction;
    public float maxDistance = 1.0f;

    // Start is called before the first frame update

    void Start()
    {
        //Makes the cursor invisible and locks it in place whenever clicked on the game window
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
        ViewObstructed();
    }

    //Main camera
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(0, mouseX, 0);
    }


    //Code for camera to see through walls (provided by Stephen Barr)
    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, maxDistance))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
            else
            {
                if (Obstruction != null)
                {
                    float distance = Vector3.Distance(transform.position, Obstruction.position);
                    if (distance > maxDistance)
                    {
                        Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                        Obstruction = null;
                    }
                }
            }
        }
        else
        {
            if (Obstruction != null)
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                Obstruction = null;
            }
        }
    }
}
