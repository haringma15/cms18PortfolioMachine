﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update() {
        if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene("Main");
    }
}
