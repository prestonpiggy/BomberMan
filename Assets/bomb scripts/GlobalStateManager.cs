using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalStateManager : MonoBehaviour
    
{   private bool dead1 = false;
    private bool dead2 = false;
    
    public GameObject won1;
    public GameObject won2;
    public GameObject draw;
    public GameObject again;
    public GameObject exit;


    public void PlayerDied(GameObject pelaaja)
    {
        if (pelaaja.gameObject.name == "Player")
        {
            dead1 = true;
            
            Invoke("declaration", .4f);
        }
        if (pelaaja.gameObject.name == "Player2")
        {
            dead2 = true;
            
            Invoke("declaration", .4f);
            
        }
    
        
    }
    void declaration()
    {

        if (dead1 == true && dead2 == false)
        {
            Debug.Log("player 2 won!");
            won2.SetActive(true);
            again.SetActive(true);
            exit.SetActive(true);


        }
        else if (dead2 == true && dead1 == false)
        {
            Debug.Log("player 1 won!");
            won1.SetActive(true);
            again.SetActive(true);
            exit.SetActive(true);
        }
        else
        {
            Debug.Log("Draw!");
            draw.SetActive(true);
            again.SetActive(true);
            exit.SetActive(true);
        }
    }
    

}

