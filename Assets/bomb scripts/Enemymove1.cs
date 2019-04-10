using UnityEngine;
using System.Collections;

public class Enemymove1 : MonoBehaviour {
    
    private IEnumerator coroutine;
    public LayerMask levelMask;
    public GameObject enemy;
    private bool dead = false;
    public Rigidbody rb;
    public GlobalStateManager2 GlobalManager2;



    // Use this for initialization
    void Start () {
        
        coroutine = move(0.63f);
        StartCoroutine(coroutine);



    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += Vector3.left * speed * Time.deltaTime;


        
    }
    IEnumerator move(float waitTime)
    {
        while (true)
        {
            //StartCoroutine(checkway(Vector3.forward));
            //StartCoroutine(checkway(Vector3.right));
            //StartCoroutine(checkway(Vector3.back));
            //StartCoroutine(checkway(Vector3.left));
            float up = checkway(Vector3.forward);
            float right = checkway(Vector3.right);
            float left = checkway(Vector3.left);
            float down = checkway(Vector3.back);
            float longest = up;
            if (longest < right)
            {
                longest = right;
            }
            if (longest < left)
            {
                longest = left;
            }
            if (longest < down)
            {
                longest = down;
            }//sunnan paatos
            
            if (longest == right)
            {
                
                liike(Vector3.right);
                //transform.position += Vector3.right * 200 * Time.deltaTime;
                //Debug.Log("pisin suunta on oik");
            }
            else if (longest == left)
            {
                
                liike(Vector3.left);
                //transform.position += Vector3.left * 200 * Time.deltaTime;
                //Debug.Log("pisin suunta on vas ");
            }
            else if (longest == down)
            {
                
                liike(Vector3.back);
                //transform.position += Vector3.back * 200 * Time.deltaTime;
                //Debug.Log("pisin suunta on bk");
            }
            else if (longest == up)
            {
                
                liike(Vector3.forward);
                //transform.position += Vector3.forward * 200;
                //Debug.Log("pisin suunta on etee");
            }

            yield return new WaitForSeconds(waitTime);





            //{
            //moved = true;

            //Debug.Log("asdasd");
            //int rnd = Random.Range(0, 100);
            //if (rnd < 15)
            //{
            //    //transform.position += Vector3.left * speed * Time.deltaTime;
            //    nextpos = gameObject.transform;
            //    nextpos.position = nextpos.position + new Vector3(-140, 0, 0);
            //    yield return new WaitForSeconds(waitTime);
            //}
            //else if (rnd > 25 && rnd < 50)
            //{
            //    //transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
            //    nextpos = gameObject.transform;
            //    nextpos.position = nextpos.position + new Vector3(0, 0, 140);
            //    yield return new WaitForSeconds(waitTime);
            //}
            //else if (rnd < 50 && rnd < 75)
            //{
            //    //transform.position += Vector3.right * speed * Time.deltaTime;
            //    nextpos = gameObject.transform;
            //    nextpos.position = nextpos.position + new Vector3(140, 0, 0);
            //    yield return new WaitForSeconds(waitTime);
            //}
            //else if (rnd <= 75)
            //{

            //    //transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
            //    nextpos = gameObject.transform;
            //    nextpos.position = nextpos.position + new Vector3(0, 0, -140);
            //    yield return new WaitForSeconds(waitTime);
            //}
            //float distCovered = (Time.time - startTime) * 2;
            //float fracJourney = distCovered / journeyLength;
            //enemy.transform.position = Vector3.Lerp(transform.position, nextpos.position, 1);
            //Debug.Log("asd1");


            //}
            //move(2f);

        }

        //moved = false;
    }
    float checkway(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position + new Vector3(0, 1, 0), direction, out hit, 23, levelMask);
        //Debug.DrawRay(transform.position + new Vector3(0, 1, 0), direction * 80, Color.red);

        //Debug.Log(hit.distance);
        //yield return new WaitForSeconds(0.2f);
        if (hit.distance == 0)
        {
            int rnd = Random.Range(0, 10);
            hit.distance = 66 +rnd;
        }
        return hit.distance;
    }
    void liike(Vector3 direction)
    {
        
       
        //aika = aika + Time.deltaTime;
        //Debug.Log(aika);
        //if (aika > 0.07)
        //{
        //    liiku = true;
           
        //}
        //if (liiku == true)
        //{
        //Debug.Log("liikkeessä");
        //transform.position += direction * 100 * Time.fixedDeltaTime;
        rb.velocity = Vector3.zero;
        rb.AddForce(direction * 1500);
        
        
       
    }
    public void OnTriggerEnter(Collider powerup)
    {
        if (powerup.gameObject.tag == "blast")
        {
            if (dead == false)
            {
                dead = true;
                GlobalManager2.PlayerDied(enemy);
                Destroy(gameObject);
                
            }
        }
    }


}
