using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _speed_enemy = 6;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed_enemy * Time.deltaTime * Vector3.down);
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Destroy(this.gameObject);

            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }
        }
        if(other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            _player.ScorePlus();
            Destroy(this.gameObject);
        }

         
    }
}
