using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController15 : MonoBehaviour
{
    float speed = 5.00f;
    float jumpForce = 5.00f;
    int TrackSpace;
    bool IsDeath = false;

    public Animator playerAnim;
    public Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDeath == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("IsMove", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("IsMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("IsMove", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("IsMove", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("IsMove", true);
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetBool("IsMove", false);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                playerAnim.SetTrigger("trigDeath");
                IsDeath = true;
            }
            JumpPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            TrackSpace = 0;
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TrackSpace < 1)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("trigFlip");

            TrackSpace++;
        }
    }
}
