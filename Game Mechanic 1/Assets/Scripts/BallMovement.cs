using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    [SerializeField]
    private GameObject m_prefabDot;
    private GameObject[] m_dotArray;
    private Camera m_cam;
    private Transform m_transform;
    private Vector3 m_direction;
    private float m_gravity = 9.81f;
    private Rigidbody m_projRigBody;


    public float force = 10;

	// Use this for initialization
	void Start ()
    {
        m_cam = Camera.main;
        m_transform = transform;
        m_projRigBody = m_transform.GetComponent<Rigidbody>();


        m_dotArray = new GameObject[15];

        for (int i = 0; i < m_dotArray.Length; i++)
        {
            GameObject tempObject = Instantiate(m_prefabDot);

            m_dotArray[i] = tempObject;

            m_dotArray[i].SetActive(false);
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 projPos = m_cam.WorldToScreenPoint(m_transform.position);
            projPos.z = 0;
            m_direction = (projPos - Input.mousePosition).normalized;

            Aim();
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_projRigBody.AddForce(m_direction * force, ForceMode.Impulse);

            for (int i = 0; i < m_dotArray.Length; i++)
            {
                m_dotArray[i].SetActive(false);
            }
        }
    }

    private void Aim()
    {
        float Sx = m_direction.x * force;
        float Sy = m_direction.y * force;

        for (int i = 0; i < m_dotArray.Length; i++)
        {
            float t = i * 0.2f;

            float Dx = Sx * t;
            float Dy = (Sy * t) - (0.5f * m_gravity * t * t);

            m_dotArray[i].transform.position = new Vector3(m_transform.position.x + Dx, m_transform.position.y + Dy, m_transform.position.z);

            m_dotArray[i].SetActive(true);
        }
    }
}
