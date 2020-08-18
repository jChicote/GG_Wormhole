using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Camera mainCamera = null;

    void Awake() 
    {
        if (instance != null) {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
