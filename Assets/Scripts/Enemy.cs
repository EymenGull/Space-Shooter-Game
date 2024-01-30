using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed_enemy = 6f;
    private Player _player;
    private Animator anim;
    private float _speed_corrector = 6f;
    private float _currentSpeed;
    [SerializeField]
    private AudioClip _explosionClip;
    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        anim = gameObject.GetComponent<Animator>();
        _speed_enemy *= 2;
        _source.clip = _explosionClip;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_currentSpeed * Time.deltaTime * Vector3.down);
        //_speed_enemy *= 1.002f;
        if (transform.position.y < -7)
        {
            Destroy(gameObject);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("OnEnemyDeath");
            _currentSpeed = 0;
            _source.Play();
            Destroy(this.gameObject, 1.5f);


                                                        
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
            anim.SetTrigger("OnEnemyDeath");
            _currentSpeed = 0;
            _source.Play();
            Destroy(this.gameObject,1.5f);


        }

         
    }
    public void SetSpeed(float speedIncrease)
    {
        _currentSpeed = _speed_enemy + speedIncrease;
    }

}
