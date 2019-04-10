using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject pelaaja;
    public Rigidbody pelaaja2;
    public float speed = 100.0f;
    public Transform seinaSpawn;
    public GameObject seinaPrefab;
    static int radius = 2;
    static int ammo=0;
    public bool dead = false;
    public GlobalStateManager2 GlobalManager2;
    public Animator animator;
    

    public Animation current;
    


    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        for (int i = 0; i <= 5; i++)
        {
            for (int k = 0; k <= 5; k++)
            {
 
                Rigidbody ammo = Instantiate(seinaPrefab, seinaSpawn.transform.position + new Vector3(i * 60.0f+60, 0, k * 60.0f+60), seinaSpawn.transform.rotation) as Rigidbody;
                
            }
        }
        seinaSpawn.transform.position = new Vector3(0f, 0f, 0f);
        for (int x = 0; x < 15; x++)
        {
            Rigidbody ammo2 = Instantiate(seinaPrefab, seinaSpawn.transform.position + new Vector3(x * 30.0f, 0, 0), seinaSpawn.transform.rotation) as Rigidbody;
        }
        seinaSpawn.transform.position = new Vector3(0f, 0f, 0f);
        for (int x = 0; x < 15; x++)
        {
            Rigidbody ammo2 = Instantiate(seinaPrefab, seinaSpawn.transform.position + new Vector3(0, 0, x * 30.0f), seinaSpawn.transform.rotation) as Rigidbody;
        }
        seinaSpawn.transform.position = new Vector3(420f, 0f, 420f);
        for (int x = 0; x < 15; x++)
        {
            Rigidbody ammo2 = Instantiate(seinaPrefab, seinaSpawn.transform.position + new Vector3(0, 0, x * -30.0f), seinaSpawn.transform.rotation) as Rigidbody;
        }
        seinaSpawn.transform.position = new Vector3(420f, 0f, 420f);
        for (int x = 0; x < 15; x++)
        {
            Rigidbody ammo2 = Instantiate(seinaPrefab, seinaSpawn.transform.position + new Vector3(x * -30.0f, 0, 0), seinaSpawn.transform.rotation) as Rigidbody;
        }





    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Pressing A");
            pelaaja.transform.position += Vector3.left * speed * Time.deltaTime;
            
        }


        else if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("Pressing W");
            pelaaja.transform.position += Vector3.forward * speed * Time.deltaTime;
            animator.SetTrigger("forward");
            
        }


        else if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Pressing S");
            pelaaja.transform.position += Vector3.back * speed * Time.deltaTime;
            //animator.Play("greyB");
            animator.SetTrigger("backward");

        }

        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Pressing D");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            //animator.SetTrigger("forward");
            //transform.position += Vector3.right * 0 * Time.deltaTime;
            pelaaja2.velocity = Vector3.zero;
            pelaaja2.angularVelocity = Vector3.zero;

        }
    }
    public void OnTriggerEnter(Collider powerup)
    {
       if (powerup.gameObject.tag == "blast" || powerup.gameObject.tag == "enemy")
        {
            Debug.Log("kuolema");
            dead = true; // 1
            
            GlobalManager2.PlayerDied(pelaaja);
            // 2
            Destroy(gameObject); // 3
        }
       if (powerup.gameObject.tag == "Power")
        {
            Debug.Log("powerup");
            Addpower();
            
        }
        if (powerup.gameObject.tag == "Ammo")
        {
            Debug.Log("ammoup");
            Addammo();
            

        }

    }
    public void Addpower()
    {
        radius = radius + 1;
        Debug.Log("tehoa lisää(player)");
        Debug.Log(radius);


    }
    public void Addammo()
    {
        ammo++;
        Debug.Log("ammoa lisää(player)");
        Debug.Log(ammo);


    }
    public static int checkpower()
    {

        return radius;
        
    }
    public static int checkammo()
    {

        return ammo;

    }



}
