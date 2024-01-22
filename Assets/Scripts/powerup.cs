using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    [SerializeField]
    private int _speed = 4;
    private bool _isTripleActive = false;
    [SerializeField]
    private int powerupId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();


            switch (powerupId)
            {
                case 0:
                    player.TripleActivator();
                    Destroy(gameObject);
                    break;
                case 1:
                    player.SpeedupActivator();
                    Destroy(gameObject);
                    break;

            }
        }
    }

}