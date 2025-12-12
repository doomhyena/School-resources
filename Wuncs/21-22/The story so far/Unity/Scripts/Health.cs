using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int Flashes;
    private SpriteRenderer sRend;


    private void Awake()
    {
        currentHealth = startingHealth;
        sRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth> 0)
        {
            StartCoroutine(Invulnerability());
        }
        else
        {
            Destroy(gameObject);
        }

    }


    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7,8,true);
        for (int i = 0; i < Flashes; i++)
        {
            sRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(iFramesDuration/(Flashes*2));
            sRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (Flashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
