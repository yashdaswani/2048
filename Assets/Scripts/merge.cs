using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class merge : MonoBehaviour
{

    public GameObject effdone;
    public GameObject eff1024;
   public bool is_static = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.GetComponent<Rigidbody2D>().velocity.magnitude!=0)
        {

            if(int.Parse(collision.collider.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text)== int.Parse(this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text))
            {
                int temp1 = int.Parse(collision.collider.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text);
                int temp2 = int.Parse(this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text);
                int final = temp1 + temp2;
                GameObject target = collision.collider.gameObject;
                this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = final.ToString();
                GetComponent<AudioSource>().Play();
                Destroy(target);
                Blocks.instance.CurrentScore = Blocks.instance.CurrentScore + final;
                Blocks.instance.ScoreText.text = "Score : " + Blocks.instance.CurrentScore.ToString();
                if(final!=1024)
                //{
                //    GameObject apply1 = Instantiate(eff1024);
                //    apply1.transform.position = this.gameObject.transform.position;
                //    Destroy(apply1, 2f);
                //}
                //else
                {
                    GameObject apply = Instantiate(effdone);

                    apply.transform.position = this.gameObject.transform.position;
                    Destroy(apply, 2f);
                }
                

                

                if (final == 4)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color2;
                }
                if (final == 8)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color3;
                }
                if (final == 16)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color4;
                }
                if (final == 32)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color5;
                }
                if (final == 64)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color6;
                }
                if (final == 128)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color7;
                }
                if (final == 256)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color8;
                }
                if (final == 512)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color9;
                }
                if (final == 1024)
                { 
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color10;
                    GameObject apply1 = Instantiate(eff1024);
                    apply1.transform.position = this.gameObject.transform.position;
                    Destroy(apply1, 2f);
                }
                if (final == 2048)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color11;
                }
                if (final == 4096)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color12;
                }
                if (final == 8192)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color13;
                }
                if (final == 16384)
                {
                    this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().fontSize = 140;
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color14;
                }
                if (final == 32768)
                {
                    this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().fontSize = 140;
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color15;
                }
                if (final == 65536)
                {
                    this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().fontSize = 140;
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color16;
                }
                if (final > 65536)
                {
                    this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().fontSize = 100;
                    this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color17;
                }
            }
        }
    }

    private void Update()
    {
        if(this.GetComponent<Rigidbody2D>().velocity.magnitude != 0)
        {
            is_static = false;
        }
        else
        {
            is_static = true;
        }
    }


}
