using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    bool isDie = false;
    float dieTimer = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDie)
        {
            dieTimer += Time.deltaTime;
            if (dieTimer >= 0.5f)
            {
                SoundManager.instance.HitSound();
                Destroy(gameObject);
            }
        }
    }

    public void Die()
    {
        anim.SetBool("isDie", true);
        isDie = true;
    }
}
