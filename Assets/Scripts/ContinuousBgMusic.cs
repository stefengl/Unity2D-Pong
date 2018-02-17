using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousBgMusic : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
