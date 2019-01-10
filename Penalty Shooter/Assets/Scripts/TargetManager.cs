using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    Vector3 initPos;
    Vector3 newPos;
    public Transform targetSpawn;

	// Use this for initialization
	void Start ()
    {
        initPos = gameObject.transform.position;
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        targetSpawn.transform.position = RandomVector();

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(gameObject,targetSpawn.transform.position, targetSpawn.transform.rotation);
            Destroy(gameObject);
        }
    }

    Vector3 RandomVector()
    {
        Vector3 randPos = new Vector3(Random.Range(5.0f, 20.0f), Random.Range(0.1f, 10.0f));

        return randPos;
    }
}
