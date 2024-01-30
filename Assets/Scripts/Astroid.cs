using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    private Vector3 rotator = new Vector3(0, 0, 3);
    [SerializeField]
    private GameObject _asteroidPrefab;
    private Player _scorer;
    [SerializeField]
    private AudioClip _explosionClip;
    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = _explosionClip;
        _scorer = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10 * Time.deltaTime * Vector3.forward);
        transform.Translate(4 * Time.deltaTime * new Vector3(Random.Range(-1.5f, 0.5f),(Random.Range(-3.0f, 0.0f)),0));
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser")){

            Destroy(other.gameObject);
            Instantiate(_asteroidPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _scorer.ScorePlus();
            _scorer.ScorePlus();


        }
        else if (other.CompareTag("Player"))
        {
            Instantiate(_asteroidPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _scorer.Damage();

        }
    }
}
