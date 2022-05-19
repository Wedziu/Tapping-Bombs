using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadObject : MonoBehaviour
{
    private void Awake()
    {
        int numBGM = FindObjectsOfType<DontDestroyOnLoadObject>().Length;
        if(numBGM>1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
