using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player Data

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private int lives = 3;
    [SerializeField] private int bombs = 3;
    private float canFire = 0.0f; //Time to fire again

    //bullets
    [SerializeField] private List<Bullet> bullets = new List<Bullet>();
    [SerializeField] private GameObject bulletPref;

    //animations
    [SerializeField] private GameObject playerExplosion;

    //Properties
    public int Lives { get => lives; set => lives = value; }
    public int Bombs { get => bombs; set => bombs = value; }
    public GameObject BulletPref { get => bulletPref; set => bulletPref = value; }

    //Event Handler for Player Damage
    public delegate void PlayerDamage();
    public static event PlayerDamage OnPlayerDamage;

    //Event Handler for Player Death
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    //Event Handler for Player Fire
    public delegate void PlayerFire();
    public static event PlayerFire OnPlayerFire;

    private void Awake()
    {
        BulletPref = bullets[0].gameObject;
    }

    private void Start()
    {
        //Subscribe to the PlayerDamage event
        OnPlayerDamage += Damage;
        //Subscribe to the PlayerFire event
        OnPlayerFire += Fire;
        OnPlayerFire += () => AudioManager.instance.PlayFireSound("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckBoundaries();
        ChangeWeapon();
        UseBomb();
    }

    //Character Movement, use WASD keys to move the player
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
    }
    void UseBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Camera Shake
            //Use the bomb to destroy all enemies on the screen
            //Make an expanding circle that destroys all enemies in the radius
            Bombs--;
        }
    }
    void CheckBoundaries()
    {
        //Check for boundaries of the game, use Main Camera to set the boundaries
        var cam = Camera.main;
        float xMax = cam.orthographicSize * cam.aspect;
        float yMax = cam.orthographicSize;
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(-xMax, transform.position.y, 0);
        }
        else if (transform.position.x < -xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, 0);
        }

        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, -yMax, 0);
        }
        else if (transform.position.y < -yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, 0);
        }
    }

    //Check for Player Fire
    public void CheckFire()
    {
        if (Input.GetMouseButton(0) && Time.time > canFire)
        {
            OnPlayerFire?.Invoke();
        }
    }

    //Player Fire
    void Fire()
    {
        Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        canFire = Time.time + fireRate;
    }

    //Check for Player Damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnPlayerDamage?.Invoke();
            collision.gameObject.GetComponent<Enemy>().TakeDamage(100);
        }
    }

    //Player Damage
    public void Damage()
    {
        Lives--;
        if (Lives < 1)
        {
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            //Game Over
            //GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }

    //Change Weapon
    public void ChangeWeapon()
    {
        //For changing weapons, use the number keys 1, 2, 3

        /*if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulletPref = bullets[0].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulletPref = bullets[1].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bulletPref = bullets[2].gameObject;
        }*/

        //This is the same as the above code, but using the Input.inputString

        switch (Input.inputString)
        {
            case "1":
                BulletPref = bullets[0].gameObject;
                break;
            case "2":
                BulletPref = bullets[1].gameObject;
                break;
            case "3":
                BulletPref = bullets[2].gameObject;
                break;
        }
    }
}