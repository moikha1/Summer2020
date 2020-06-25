using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    Rigidbody rb;
    Transform t;
    float speed = 10.0f;
    bool isGrounded = true;
    Animator anim;
    CharacterController character;
    //float angle = 0.0f;
    
    void Start () {
        
        t = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();//GetComponent<CharacterController>().attachedRigidbody;
	}

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    void FixedUpdate () {
        //angle = t.eulerAngles.y;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            speed = 5.0f;
        else
            speed = 10.0f;

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.W) && ((!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))) && !Input.GetKey(KeyCode.S)){
                //rb.velocity = speed * (Quaternion.AngleAxis(angle, Vector3.up)*(Vector3.forward));
                character.SimpleMove(speed * transform.TransformDirection(Vector3.forward));
                anim.SetInteger("move", 1);
            }
            else if (Input.GetKey(KeyCode.A) && ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))) && !Input.GetKey(KeyCode.D)){
                //rb.velocity = speed * (Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.left));
                character.SimpleMove(speed * transform.TransformDirection(Vector3.left));
                anim.SetInteger("move", 2);
            }
            else if (Input.GetKey(KeyCode.S) && ((!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))) && !Input.GetKey(KeyCode.W)){
                //rb.velocity = speed * (Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.back));
                character.SimpleMove(speed * transform.TransformDirection(Vector3.back));
                anim.SetInteger("move", 3);
            }
            else if (Input.GetKey(KeyCode.D) && ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))) && !Input.GetKey(KeyCode.A)){
                //rb.velocity = speed * (Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.right));
                character.SimpleMove(speed * transform.TransformDirection(Vector3.right));
                anim.SetInteger("move", 4);
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)){
                //rb.velocity = (1.0f / 1.4142f) * speed * (Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.forward + Vector3.left));
                character.SimpleMove((1.0f / 1.4142f) * speed * transform.TransformDirection(Vector3.forward + Vector3.left));
                anim.SetInteger("move", 5);
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A)){
                //rb.velocity = (1.0f / 1.4142f) * speed * (Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.forward + Vector3.right));
                character.SimpleMove((1.0f / 1.4142f) * speed * transform.TransformDirection(Vector3.forward + Vector3.right));
                anim.SetInteger("move", 6);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D)){
                //rb.velocity = (1.0f / 1.4142f) * speed * (Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.back + Vector3.left));
                character.SimpleMove((1.0f / 1.4142f) * speed * transform.TransformDirection(Vector3.back + Vector3.left));
                anim.SetInteger("move", 7);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A)){
                //rb.velocity = (1.0f / 1.4142f) * speed * (Quaternion.AngleAxis(angle, Vector3.up) * (Vector3.back + Vector3.right));
                character.SimpleMove((1.0f / 1.4142f) * speed * transform.TransformDirection(Vector3.back + Vector3.right));
                anim.SetInteger("move", 8);
            }
            
        }
        else
        {
            rb.velocity = 0 * new Vector3(0, 0, 0);
            anim.SetInteger("move", 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.angularVelocity = speed * Vector3.down;
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.angularVelocity = speed * Vector3.up;
        }
        else
            rb.angularVelocity = 0 * new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            //rb.velocity += speed * (Vector3.up) * 1.0f;
            character.Move(speed * (Vector3.up) * 1.0f);
            isGrounded = false;
        }
        
        if (!isGrounded)
        {
            //anim.enabled = false;
        }
        else
        {
            //anim.enabled = true;
        }

        if (anim.enabled&&!isGrounded)
        {
            //rb.velocity -= 9.8f * (Vector3.up) * 0.05f;
        }

    }
}
