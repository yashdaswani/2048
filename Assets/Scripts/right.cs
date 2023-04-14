using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class right : MonoBehaviour
{
    public GameObject effdone;
    public GameObject eff1024;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.transform.parent.CompareTag("spawningBlock") || this.gameObject.transform.parent.CompareTag("block"))
        {
            if (collision.gameObject.tag == "block")
            {
                int my_value = int.Parse(this.gameObject.transform.parent.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text);
                int target_value = int.Parse(collision.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text);
                if (my_value == target_value)
                {
                    int final = target_value * 2;
                    Destroy(collision.transform.gameObject);
                    this.gameObject.transform.parent.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = (my_value + target_value).ToString();
                    Blocks.instance.CurrentScore = Blocks.instance.CurrentScore + (my_value + target_value);
                    Blocks.instance.ScoreText.text = "Score : " + Blocks.instance.CurrentScore.ToString();
                    if (final == 1024)
                    {
                        GameObject apply1 = Instantiate(eff1024);
                        apply1.transform.position = this.gameObject.transform.position;
                        Destroy(apply1, 2f);
                    }
                    else
                    {
                        GameObject apply = Instantiate(effdone);

                        apply.transform.position = this.gameObject.transform.position;
                        Destroy(apply, 2f);
                    }
                    if (final == 4)
                    {
                        this.gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Blocks.instance.color2;
                    }
                    if (final == 8)
                    {
                        this.gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Blocks.instance.color3;
                    }
                    if (final == 16)
                    {
                        this.gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Blocks.instance.color4;
                    }
                    if (final == 32)
                    {
                        this.gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Blocks.instance.color5;
                    }
                    if (final == 64)
                    {
                        this.gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Blocks.instance.color6;
                    }
                    if (final == 128)
                    {
                        this.gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Blocks.instance.color7;
                    }
                    if (final == 256)
                    {
                        this.gameObject.transform.parent.GetComponent<SpriteRenderer>().color = Blocks.instance.color8;
                    }
                    if (final == 512)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color9;
                    }
                    if (final == 1024)
                    {

                        this.gameObject.GetComponent<SpriteRenderer>().color = Blocks.instance.color10;
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
                }

            }
        }
    }
  }
