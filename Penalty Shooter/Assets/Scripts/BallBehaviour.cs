using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    [SerializeField] GameObject Disc;
    [SerializeField] float multiplier;
    Vector3 initPos;
    Vector3 pullPos;
    private bool ballMove;
    private float timeFail;
    public Transform SpawnPoint;

    private void Start()
    {
        ballMove = false;
    }

    private void FixedUpdate()
    {
        BallTime();
    }

    void OnMouseDown()
    {
            initPos = transform.position;
    }

    void OnMouseDrag()
    {
            pullPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    void OnMouseUp()
    {
        if (ballMove == false)
        {
            Disc.GetComponent<Rigidbody>().AddForce((initPos - pullPos) * Vector3.Distance(pullPos, initPos) * multiplier);
            ballMove = true;
        }
    }

    void BallTime()
    {
        if (ballMove == false)
        {
            timeFail = 5;
        }
        if (ballMove == true)
        {
            timeFail -= Time.deltaTime;
            Debug.Log(timeFail);
            if (timeFail < 0)
            {
                Respawn();
            }
        }
    }

    void Respawn()
    {
        Instantiate(Disc,SpawnPoint.transform.position,SpawnPoint.transform.rotation);
        Destroy(Disc);
        Start();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Target")
        {
            Respawn();
        }
    }
}