using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float smouth;
    private Transform player;
    [SerializeField]
    private float Y;



    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 startPosition = new Vector3(player.position.x, Y, -1f);

        Vector3 smouthPosition = Vector3.Lerp(transform.position, startPosition, smouth);

        transform.position = smouthPosition;
    }
  }
