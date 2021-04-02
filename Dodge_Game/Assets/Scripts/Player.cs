using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 3;

    //Getter
    public int GetHp()
    {
        return hp;
    }

    //Setter
    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public void Update()
    {
        if (hp > 0)
        {
            float posX = 0.0f, posY = 0.0f;
            /*        
                    if(Input.GetKey(KeyCode.A))
                    {
                        posX -= 1;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        posX += 1;
                    }
                    if (Input.GetKey(KeyCode.W))
                    {
                        posY -= 1;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        posY += 1;
                    }   
             */
            posX = Input.GetAxis("Horizontal");
            posY = Input.GetAxis("Vertical");

            Vector3 pos = gameObject.transform.position;
            pos.x += posX * Time.deltaTime * 10;
            pos.y += posY * Time.deltaTime * 10;

            if(pos.x < -8.25f)
            {
                pos.x = -8.25f;
            }
            else if (pos.x > 8.25f)
            {
                pos.x = 8.25f;
            }
            else if (pos.y < -4.7f)
            {
                pos.y = -4.7f;
            }
            else if (pos.y > 4.7f)
            {
                pos.y = 4.7f;
            }

            gameObject.transform.position = pos;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Enemy"))
        {
            hp -= 1;
            print(hp);
        }
    }
}
