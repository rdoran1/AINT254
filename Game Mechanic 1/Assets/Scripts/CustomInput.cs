﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInput : MonoBehaviour {

    // Use this for initialization
    private void OnGUI()
    {

        GUI.Label(new Rect(5.0f, 5.0f, 200.0f, 30.0f), "Horizontal Axis: " + Input.GetAxis("Horizontal"));
    }
}
