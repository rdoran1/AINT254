using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    private Transform m_transform;
    public AnimationCurve curve;

	// Use this for initialization
	void Start ()
    {
        m_transform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        RandonVector();
    }

    private void Step()
    {
        int randomNumber = Random.Range(0, 4);
        float xValue = 0;
        float zValue = 0;

        if (randomNumber == 0)
        {
            xValue = 0.1f;
        }
        else if (randomNumber == 1)
        {
            xValue = -0.1f;
        }
        else if (randomNumber == 2)
        {
            zValue = 0.1f;
        }
        else if (randomNumber == 3)
        {
            zValue = -0.1f;
        }
        m_transform.position += new Vector3(xValue, 0, zValue);
    }

    private void StepArray()
    {
        int[] arrayOfInts = new int[5];
        arrayOfInts[0] = 0;
        arrayOfInts[1] = 1;
        arrayOfInts[2] = 2;
        arrayOfInts[3] = 3;
        arrayOfInts[4] = 0;

        int randomIndex = Random.Range(0, 5);
        int randomNumber = arrayOfInts[randomIndex];

        float xValue = 0;
        float zValue = 0;

        if (randomNumber == 0)
        {
            xValue = 0.1f;
        }
        else if (randomNumber == 1)
        {
            xValue = -0.1f;
        }
        else if (randomNumber == 2)
        {
            zValue = 0.1f;
        }
        else if (randomNumber == 3)
        {
            zValue = -0.1f;
        }
        m_transform.position += new Vector3(xValue, 0, zValue);
    }

    private void StepFloat()
    {
        float ranFloat = Random.Range(0 , 1.0f);

        float xValue = 0;
        float zValue = 0;

        if (ranFloat <= 0.25f)
        {
            xValue = 0.1f;
        }
        else if (ranFloat > 0.25f && ranFloat <= 0.5f)
        {
            xValue = -0.1f;
        }
        else if (ranFloat > 0.5f && ranFloat <= 0.75f)
        {
            zValue = 0.1f;
        }
        else if (ranFloat > 0.75f && ranFloat <= 1.0f)
        {
            zValue = -0.1f;
        }
        m_transform.position += new Vector3(xValue, 0, zValue);
    }

    private void StepCurve()
    {
        float xValue = 0;
        float zValue = 0;

        float randomCurveValue = Random.Range(0.0f, 1.0f);

        float ranFloat = curve.Evaluate(randomCurveValue);

        if (ranFloat <= 0.25f)
        {
            xValue = 0.1f;
        }
        else if (ranFloat > 0.25f && ranFloat <= 0.5f)
        {
            xValue = -0.1f;
        }
        else if (ranFloat > 0.5f && ranFloat <= 0.75f)
        {
            zValue = 0.1f;
        }
        else if (ranFloat > 0.75f && ranFloat <= 1.0f)
        {
            zValue = -0.1f;
        }
        m_transform.position += new Vector3(xValue, 0, zValue);
    }

    private void RandonVector()
    {
        float xValue = Random.Range(-1.0f, 1.0f);
        float zValue = Random.Range(-1.0f, 1.0f);

        m_transform.position += new Vector3(xValue, 0.0f, zValue);
    }
}
