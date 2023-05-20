using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float rotationSpeed = 180.0f;
    public TextMeshProUGUI helpText, helpTextMessage;
    private Rigidbody rb;
    private Animator playerAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerController();
        AccessHelp();
    }

    void PlayerController()
    {
        //Users horizontal and vertical movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
    }

    void AccessHelp()
    {
        if(Input.GetKey(KeyCode.H))
        {
            helpText.gameObject.SetActive(false);
            helpTextMessage.gameObject.SetActive(true);
        }
        else
        {
            helpText.gameObject.SetActive(true);
            helpTextMessage.gameObject.SetActive(false);
        }
    }
}
