using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private int _speed_laser = 8;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed_laser * Time.deltaTime * Vector3.up);
        if (transform.position.y > 7)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
