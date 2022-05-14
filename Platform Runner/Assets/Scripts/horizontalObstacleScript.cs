using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class horizontalObstacleScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float pushForce;
    public bool isActive;
    [SerializeField] private int num;

    void Update()
    {
        
            if (isActive == false)
            {
            transform.position = new Vector3(15, 2, transform.position.z);
                StartCoroutine(push());

            }
        
       
    }

    IEnumerator push()
    {
        isActive = true;
        transform.DOMoveX(transform.position.x - 15, 3);
        yield return new WaitForSeconds(4);
        transform.DOMoveX(transform.position.x + 15, 1.5f);
        yield return new WaitForSeconds(2.5f);
        isActive = false;
    }
}
