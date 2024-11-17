using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public float _alphaThreshold = 0.1f;
    
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = _alphaThreshold;
    }

  
    void Update()
    {
        
    }
}
