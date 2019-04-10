using UnityEngine;
using System.Collections;

public class BombDrop2 : MonoBehaviour
{

    public GameObject BombPrefab;
    public Transform pelaaja2;
    private GameObject bomb;
    
    
    
    private int ammocount;
    static int planted = 0;



    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            ammocount = Player2.checkammo();
            if (ammocount >= planted)
            {


                Blasting();
                planted++;
            }

        }



    }
    void Blasting()
    {
        bomb = (GameObject)Instantiate(BombPrefab, new Vector3(Mathf.RoundToInt(pelaaja2.position.x / 30) * 30,
        10, Mathf.RoundToInt(pelaaja2.position.z / 30) * 30),
        BombPrefab.transform.rotation);
        bomb.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(Waitcollider());
        




    }
    
    
    IEnumerator Waitcollider()
    {

        yield return new WaitForSeconds(0.2f);
        bomb.GetComponent<BoxCollider>().enabled = true;
    }
    public static void Bombdetonated()
    {
        planted--;
    }

}
