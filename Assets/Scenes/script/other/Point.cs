using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Point : MonoBehaviour
{
    Text point;

    void Start()
    {
        point = GetComponent<Text>();
    }

  
    void Update()
    {
        PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

       point.text = Convert.ToString(player.getPoint());

    }


    public void DestuirPlaca()
    {
        Destroy(gameObject);
    }

}
