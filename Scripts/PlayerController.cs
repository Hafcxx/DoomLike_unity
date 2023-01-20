using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D theRB;
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private Vector2 mouseInput;
    public Camera viewCam;
    public GameObject fireImpact; 

    public float mouseSensitivity = 1f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PLAYER MOVEMENT
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * moveInput.y;

        Vector3 moveVertical = transform.right * moveInput.x;

        theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        

        //MOUSE
        mouseInput = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z - mouseInput.x);

        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        //shooting

        if (Input.GetMouseButtonDown(0))
        {   
            //Estamos enviando un rayo, despues consultamos si este golpeó
            Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, .5f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Im HITTING" + hit.transform.name);
                Instantiate(fireImpact, hit.point, transform.rotation);
            }else
            {
                Debug.Log("Not hitting");
            }
        }
    }
}
