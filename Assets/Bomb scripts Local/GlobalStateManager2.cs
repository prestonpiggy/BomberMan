using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalStateManager2 : MonoBehaviour

{   private bool dead1 = false;
    private bool dead2 = false;
    int enemiesdied = 0;
    public GameObject won1;
    public GameObject won2;

    public GameObject draw;
    public GameObject again;
    public GameObject exit;

    
    public void PlayerDied(GameObject pelaaja)
    {
        if (SceneManager.sceneCountInBuildSettings == 1)
        {
            if (pelaaja.gameObject.name == "Player")
            {
                dead1 = true;


                Invoke("declaration", .4f);
            }
            if (pelaaja.gameObject.tag == "enemy")
            {
                enemiesdied++;
                if (enemiesdied >= 6)
                {
                    dead2 = true;
                    Invoke("declaration", .4f);
                }


            }

        }
        else
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
    }
    void declaration()
    {
        if (SceneManager.sceneCountInBuildSettings == 1)
        {

            if (dead1 == true && dead2 == false)
            {
                Debug.Log("enemy won!");
                won2.SetActive(true);
                again.SetActive(true);
                exit.SetActive(true);


            }
            else if (dead2 == true)
            {
                Debug.Log("player  won!");
                won1.SetActive(true);
                again.SetActive(true);
                exit.SetActive(true);
            }

        }else {
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

}

