using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float bgY;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + bgY, player.position.z);
    }
}
