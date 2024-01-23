using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _enemyPrefab;
    private float _fireRate = 5.0f;
    private float am_time = 0.0f;
    private int i = 0;
    private int shotCount = 0;
    private int enemyNum = 0;
    private float reloadTime = 3f; // Şarjör değiştirme süresi
    private bool isReloading = false; // Şarjör değiştirme durumunu kontrol etmek için
    //private readonly float _x = Random.Range(-9.0f, 9.0f);
    private float _bornTime = 3.0f;
    private bool isEnemy = false;
    [SerializeField]
    private int _lives = 3;
    private Spawner _spawner;
    [SerializeField]
    private GameObject _tripleshotPrefab;
    [SerializeField]
    private GameObject _powerupPrefab;
    [SerializeField]
    private GameObject _shieldPrefab;
    private powerup _powerup;
    private bool _isTripleActive = false;
    private bool _isSpeedupActive = false;
    [SerializeField]
    private int _score = 0;
    UIManager uimanager;
    [SerializeField]
    private GameManager _gameEnder;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
        _spawner = GameObject.Find("SpawnManager").GetComponent<Spawner>();
        if(_spawner == null)
        {
            Debug.LogError("Spawn manager is null");
        }
        uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameEnder = GameObject.Find("Game_Manager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && !isReloading)
        {
            LaserMovement();
        }

       /* if(Time.time > 5.0f && !isEnemy)
        {
            enemyNum++;
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-9.0f, 9.0f), 10, 0), Quaternion.identity);
            if (enemyNum >= 1)
            {
                StartCoroutine(EnemyBorn());
                
            }
        }*/
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        transform.Translate(_speed * Time.deltaTime * new Vector3(horizontalInput, verticalInput, 0));

        if (transform.position.x > 10)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);

        }
        else if (transform.position.x < -10)
        {
            transform.position = new Vector3(10, transform.position.y, 0);

        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 0), 0);
    }
    IEnumerator Reload()
    {
        isReloading = true; // Şarjör değiştirme sürecini başlat
        yield return new WaitForSeconds(reloadTime); // Belirtilen süre boyunca bekle
        shotCount = 0; // Atış sayısını sıfırla
        isReloading = false; // Şarjör değiştirme sürecini bitir
    }
    void LaserMovement() {

        if (_isTripleActive == false)
        {

            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            shotCount++;
        }
        else { Instantiate(_tripleshotPrefab, transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity); }

        if (shotCount >= 10)
        {
            StartCoroutine(Reload());
        }
        
    }

    /*IEnumerator EnemyBorn()
    {
        isEnemy = true;
        yield return new WaitForSeconds(_bornTime);
        enemyNum = 0;
        isEnemy = false;
    }*/

    public void Damage()
    {
        _lives--;
        uimanager.UpdateLives(_lives);

        if(_lives < 1) 
        {
            _spawner.DeadController();
            Destroy(this.gameObject);
            uimanager.GameOver();
            _gameEnder.gameEnder();
        }
    }

    /* public void TripleActivator()
     {
         _powerup.TripleActivator();
     }*/

    IEnumerator TripleActivation()
    {
        yield return new WaitForSeconds(5);
        _isTripleActive = false;
    }

    public void TripleActivator()

    {
        _isTripleActive = true;
        StartCoroutine(TripleActivation());
        
    }
    IEnumerator SpeedupActivation()
    {
        _speed = 20f;
        yield return new WaitForSeconds(5);
        _isSpeedupActive = false;
        _speed = 5.5f;
    }

    public void SpeedupActivator()
    {
        _isSpeedupActive = true;
        StartCoroutine(SpeedupActivation());
    }
    public void ScorePlus()
    {
        _score = _score + 10;
        uimanager.UpdateScore(_score);
    }

}
