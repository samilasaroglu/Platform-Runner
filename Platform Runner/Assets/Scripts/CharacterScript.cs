using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    [SerializeField] private float speed;
    private Vector3 move;
    [SerializeField] private Animator anim;
    private bool isRunning;
    public bool isFinish,isPaint,isRankOk;
    [SerializeField] private GameObject paint;
    [SerializeField] private GameObject wall;
  


   
    void Update()
    {
      
        move = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        if (Input.GetAxis("Vertical") >= 0)
        {
            transform.Translate(move * Time.deltaTime);
        }
        else
        {
            transform.position += new Vector3(0, 0, 0);
        }

        if (Input.GetAxis("Vertical")*speed > 0 && isRunning==false)
        {
            anim.SetBool("run", true);
            isRunning = true;
        }
        else if(Input.GetAxis("Vertical")*speed <= 0 && isRunning == true)
        {
            anim.SetBool("run", false);
            isRunning = false;
        }

        if(transform.position.x < -7.5f || transform.position.x > 7.5f)
        {
            
            basaDon();

        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle" || collision.gameObject.tag=="human" )
        {
            if (isFinish == false)
            {
                basaDon();
            }
        }

        if (collision.gameObject.tag == "Finish")
        {
            speed = 0;
            isFinish = true;
            anim.SetBool("dance", true);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            if (isPaint == true)
            {
                paint.SetActive(true);
                wall.SetActive(true);
            }
           
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rankPoint")
        {
            isRankOk = true;
        }
    }

    void basaDon()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
