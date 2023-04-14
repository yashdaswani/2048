using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Blocks : MonoBehaviour
{
    public GameObject deadline;
    public GameObject blockprefab;
    public GameObject top_prefab;
    public GameObject bottom_prefab;
    public GameObject blockParent;
    public GameObject[] positions;
    public GameObject go;
    public GameObject reminder;
    public static Blocks instance;
    bool spawnNow = false;
   public static bool checktouch = true; 
    public int CurrentScore = 0;
    public Text ScoreText;
    public float value;
    public float randompoints;
    public GameObject touchp;
    public GameObject trianglepanel;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public Color color8;
    public Color color9;
    public Color color10;
    public Color color11;
    public Color color12;
    public Color color13;
    public Color color14;
    public Color color15;
    public Color color16;
    public Color color17;
    public Camera camera_;
    public float gap;
    public float x, y;
    public int time = 300;
    public Text TimeText;
    public AudioSource gameoversound;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void spawnWalls()
    {
        Vector2 top = camera_.ViewportToWorldPoint(new Vector3(0.5f, 1, camera_.nearClipPlane));
        Vector2 bottom = camera_.ViewportToWorldPoint(new Vector3(0.5f, 0, camera_.nearClipPlane));
        Instantiate(top_prefab, top, Quaternion.identity);
        Instantiate(bottom_prefab, bottom, Quaternion.identity);
    }


    public void fast()
    {
        if (blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.magnitude!=0)
        {
            blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().gravityScale = 1;
        }

    }


    void Start()
    {
        
        if(SceneManager.GetActiveScene().buildIndex== 1)
        {
            StartCoroutine(timemode());
        }
        
        x = Screen.width;
        y = Screen.height;
        float ratio2 = y / x;
        float numerator = (float)(0.17000 * ((float)1920 / (float)1080));
        float denomintor =ratio2;
        float finalsize = numerator / denomintor;
        float num = (float)(1 * ((float)1920 / (float)1080));
        float num1 = (float)(1 * ((float)1920 / (float)1080));
        float finalt = num / denomintor;
        float finalt1 = num1 / denomintor;
        touchp.transform.localScale = new Vector2(finalt, touchp.transform.localScale.y);
        trianglepanel.transform.localScale = new Vector2(finalt1, trianglepanel.transform.localScale.y);
        blockprefab.transform.localScale = new Vector2(finalsize, finalsize);
        spawnWalls();
        SpawnBlock();
    }
    void Update()
    {

        
        if (Blocks.instance.CurrentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Blocks.instance.CurrentScore);
        }
        endgame();

        if(checktouch)
        {
            touchControl();
        }

        if(blockParent.transform.GetChild(blockParent.transform.childCount-1).GetComponent<Rigidbody2D>().velocity.y == 0 && !spawnNow)
        {
            spawnNow = true;
            StartCoroutine(changeTag(blockParent.transform.GetChild(blockParent.transform.childCount - 1).gameObject));
            SpawnBlock();
            Invoke("makeFalse", 1);

        }


        //if(blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.magnitude!=0)
        //{
        //    blockParent.transform.GetChild(blockParent.transform.childCount - 1).tag = "spawningBlock";
        //}
        
    }
    IEnumerator changeTag(GameObject block)
    {
        yield return new WaitForSeconds(1);
        block.gameObject.tag = "block";
    }
    void makeFalse()
    {
        spawnNow = false;
    }

    public void reminderopen()
    {
        reminder.SetActive(true);
    } 
    public void reminderclose()
    {
        reminder.SetActive(false);
    }
    


    IEnumerator timemode()
    {
        yield return new WaitForSeconds(1);
        time = time - 1;
        if(time>30)
        {
            TimeText.color = color2;
        }
        else
        {
           
            TimeText.color = color1;
        }

        if(time==30)
        {
            reminderopen();
            Invoke("reminderclose", 3.0f);
        }

        if (time % 60 <= 9)
            TimeText.text = "Time Left "+(time / 60).ToString() + " : 0" + (time % 60).ToString();
        else
            TimeText.text = "Time Left " + (time / 60).ToString() + " : " + (time % 60).ToString();

        if(time>0)
        {
            StartCoroutine(timemode());
        }

        if(time==0)
        {
            SceneManager.LoadScene(2);
        }



    }

    public void timeextend()
    {
        time = time + 120;
    }

    void endgame()
    {

        for (int i = 0; i < blockParent.transform.childCount; i++)
        {
            if (blockParent.transform.GetChild(i).GetComponent<Rigidbody2D>().velocity.magnitude == 0 && blockParent.transform.GetChild(i).CompareTag("block"))
            {
                if (blockParent.transform.GetChild(i).transform.position.y > (deadline.transform.position.y-2))
                {

                    gameoversound.Play();
                    SceneManager.LoadScene(2);

                }
            }
        }
     }




    public void SpawnBlock()
    {
        
        int randomNum = Random.Range(0, 5);
        Vector2 p1 = camera_.ViewportToWorldPoint(new Vector3(0.265f + gap, 0.7f, camera_.nearClipPlane));
        Vector2 p2 = camera_.ViewportToWorldPoint(new Vector3(0.43f + gap, 0.7f, camera_.nearClipPlane));
        Vector2 p3 = camera_.ViewportToWorldPoint(new Vector3(0.592f + gap, 0.7f, camera_.nearClipPlane));
        Vector2 p4 = camera_.ViewportToWorldPoint(new Vector3(0.755f + gap, 0.7f, camera_.nearClipPlane));
        Vector2 p5 = camera_.ViewportToWorldPoint(new Vector3(0.915f + gap, 0.7f, camera_.nearClipPlane));
        //Vector2 p6 = camera_.ViewportToWorldPoint(new Vector3(0.4998f - gap, 0.7f, camera_.nearClipPlane));
        Vector2 selectedpos=new Vector2();
        

        switch (randomNum)
        {
            case 0:
                 selectedpos = p1;
                 break;
            case 1:
                selectedpos = p2;
                break;
            case 2:
                selectedpos = p3;
                break;
            case 3:
                selectedpos = p4;
                break;
            case 4:
                selectedpos = p5;
                break;
            //case 5:
            //    selectedpos = p6;
            //    break;

        }

        go = Instantiate(blockprefab, selectedpos, Quaternion.identity);

        value = getpoints();
        go.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = value.ToString();
        if (value == 2)
        {
            go.GetComponent<SpriteRenderer>().color = color1;
        }
        if (value == 4)
        {
            go.GetComponent<SpriteRenderer>().color = color2;
        }
        if (value == 8)
        {
            go.GetComponent<SpriteRenderer>().color = color3;
        }
        if (value == 16)
        {
            go.GetComponent<SpriteRenderer>().color = color4;
        }
        if (value == 32)
        {
            go.GetComponent<SpriteRenderer>().color = color5;
        }
        if (value == 64)
        {
            go.GetComponent<SpriteRenderer>().color = color6;
        }
        if (value == 128)
        {
            go.GetComponent<SpriteRenderer>().color = color7;
        }
        if (value == 256)
        {
            go.GetComponent<SpriteRenderer>().color = color8;
        }
        if (value == 512)
        {
            go.GetComponent<SpriteRenderer>().color = color9;
        }
        if (value == 1024)
        {
            go.GetComponent<SpriteRenderer>().color = color10;
        }
        if (value == 2048)
        {
            go.GetComponent<SpriteRenderer>().color = color11;
        }
        if (value == 4096)
        {
            go.GetComponent<SpriteRenderer>().color = color12;
        }
        if (value == 8192)
        {
            go.GetComponent<SpriteRenderer>().color = color13;
        }
        if (value == 16384)
        {
            go.GetComponent<SpriteRenderer>().color = color14;
        }
        if (value == 32768)
        {
            go.GetComponent<SpriteRenderer>().color = color15;
        }
        if (value == 65536)
        {
            go.GetComponent<SpriteRenderer>().color = color16;
        }
        if (value > 65536)
        {
            go.GetComponent<SpriteRenderer>().color = color17;
        }
        
        go.transform.parent = blockParent.transform;
        

    }

   


    public float getpoints()
    {
        if (CurrentScore <= 80)
        {
            randompoints = Mathf.Pow(2, Random.Range(1, 6));
        }
        if (CurrentScore > 80 && CurrentScore <= 2500)
        {
            randompoints = Mathf.Pow(2, Random.Range(1, 7));
        }
        if (CurrentScore > 2500 && CurrentScore <= 6000)
        {
            randompoints = Mathf.Pow(2, Random.Range(1, 8));
        }
        if (CurrentScore > 6000 && CurrentScore <= 15000)
        {
            randompoints = Mathf.Pow(2, Random.Range(1, 9));
        }
        if (CurrentScore > 15000)
        {
            randompoints = Mathf.Pow(2, Random.Range(1, 10));
        }

        
       
        return randompoints;
    }


    public void touchControl()
    {
        if (Input.touchCount > 0)
        {
            Vector3 p1 = camera_.ViewportToWorldPoint(new Vector3(0.265f + gap, 1, camera_.nearClipPlane));
            Vector3 p2 = camera_.ViewportToWorldPoint(new Vector3(0.43f + gap, 1, camera_.nearClipPlane));
            Vector3 p3 = camera_.ViewportToWorldPoint(new Vector3(0.592f + gap, 1, camera_.nearClipPlane));
            Vector3 p4 = camera_.ViewportToWorldPoint(new Vector3(0.755f + gap, 1, camera_.nearClipPlane));
            Vector3 p5 = camera_.ViewportToWorldPoint(new Vector3(0.915f + gap, 1, camera_.nearClipPlane));
            //Vector3 p6 = camera_.ViewportToWorldPoint(new Vector3(0.9996f - gap, 1, camera_.nearClipPlane));
            Touch touch = Input.GetTouch(0);
            

            Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit)
            {
                if (hit.collider.CompareTag("l1"))
                {

                    if (blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.magnitude != 0)
                    {
                        blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position = new Vector2(p1.x, blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position.y);

                    }
                }
                if (hit.collider.CompareTag("l2"))
                {
                    if (blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.magnitude != 0)
                    {
                        blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position = new Vector2(p2.x, blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position.y);

                    }
                }
                if (hit.collider.CompareTag("l3"))
                {
                    if (blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.magnitude != 0)
                    {
                        blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position = new Vector2(p3.x, blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position.y);

                    }
                }
                if (hit.collider.CompareTag("l4"))
                {
                    if (blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.magnitude != 0)
                    {
                        blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position = new Vector2(p4.x, blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position.y);

                    }
                }
                if (hit.collider.CompareTag("l5"))
                {
                    if (blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.magnitude != 0)
                    {
                        blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position = new Vector2(p5.x, blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position.y);

                    }
                }
                //if (hit.collider.CompareTag("l6"))
                //{
                //    if (blockParent.transform.GetChild(blockParent.transform.childCount - 1).GetComponent<Rigidbody2D>().velocity.magnitude != 0)
                //    {
                //        blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position = new Vector2(p6.x, blockParent.transform.GetChild(blockParent.transform.childCount - 1).transform.position.y);

                //    }
                //}
            }
            
        }
    }
}
