using UnityEngine;
using System.Collections;

public class Bomb2 : MonoBehaviour {

    public GameObject BlastPrefab;
    public LayerMask levelMask;
    public GameObject blast;
    public int radius2;
    public AudioSource audio;




    private bool exploded = false;

    // Use this for initialization
    void Start () {
        Invoke("explode", 2f);
        AudioSource audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        
	
	}






    
    public void explode()
    {
        radius2 = Player2.checkpower();
        Debug.Log(radius2);

        GetComponent<SpriteRenderer>().enabled = false;
        
        exploded = true;
        blast = (GameObject)Instantiate(BlastPrefab, transform.position, Quaternion.identity);
        Destroy(blast, 1f);

        GetComponent<BoxCollider>().enabled = true;
        //transform.FindChild("Collider").gameObject.SetActive(false);
        
        //GetComponent<BoxCollider>().enabled = false;

        
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));

        //Debug.Log("pam");
        audio.Play();
        BombDrop2.Bombdetonated();
        Destroy(gameObject, 1f);

    }
    private IEnumerator CreateExplosions(Vector3 direction)
    {
        
        for (int i = 1; i < radius2; i++)
            
        {

            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0, 1, 0), direction, out hit, i * 30, levelMask);
            Debug.DrawRay(transform.position + new Vector3(0, 30, 0), direction * 100, Color.red);
            
            if (!hit.collider)
            {
                blast =  (GameObject)Instantiate(BlastPrefab,transform.position + (i * direction * 30), BlastPrefab.transform.rotation);

            }
            else if (hit.collider.gameObject.tag == "box")
            {
                
                blast = (GameObject)Instantiate(BlastPrefab, transform.position + (i * direction * 30), BlastPrefab.transform.rotation);
                Debug.Log("laatikkoray");
                Destroy(blast, (1f - i / 5));
                break;

            }


            else
            {
                break;
            }
            

            if (GameObject.FindGameObjectWithTag("blast") != null)
            {
                Destroy(blast, (1f - i / 5));
            }

            yield return new WaitForSeconds(.05f);
        }

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "box")
        {
            Debug.Log("laatikko");
            Destroy(other);

        }
        if (!exploded && other.gameObject.tag == "blast")
        { // 1 & 2  
            Debug.Log("osuma pommiin");
            CancelInvoke("Explode"); // 2
            explode(); // 3
            


        }
        
    }
}

