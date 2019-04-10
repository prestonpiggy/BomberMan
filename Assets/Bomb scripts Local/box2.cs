using UnityEngine;
using System.Collections;


public class box2 : MonoBehaviour {
    public GameObject Ammoloot;
    public GameObject Powerloot;
    private GameObject loot;
    
    


    // Use this for initialization
    void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter(Collider box)
    {
        if (box.gameObject.tag == "blast")
        {
            Debug.Log("hajota laatikko");
            Invoke("droploot", 1);
        }
        if (box.gameObject.tag == "Player")
        {
            Debug.Log("pelaaja osui");

            Destroy(loot);

            Invoke("Destroy", 0.1f);
            Destroy(gameObject);
            Debug.Log("destroy collider");

        }
    }
    public void droploot()
    {
        int rnd = Random.Range(0, 100);
        Debug.Log(rnd);
        if (rnd < 20)
        {
            gameObject.tag = "Power";
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = true;
            loot = (GameObject)Instantiate(Powerloot, transform.position, transform.rotation);

        }
        else if (rnd > 80)
        {
            gameObject.tag = "Ammo";
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = true;
            loot = (GameObject)Instantiate(Ammoloot, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("destroy boxdroploot");
            Destroy(gameObject);
        }

    }
    IEnumerator Destroy()
    {
        Debug.Log("destroy box");
        yield return new WaitForSeconds(.05f);
        Destroy(gameObject);
    }



}
