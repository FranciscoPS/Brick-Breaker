using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BrickController : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField, Range(0, 100)] float powerUpChance;

    [SerializeField] List<Color> hpColors;
    [SerializeField] List<GameObject> powerUpPrefs;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = hpColors[hp - 1];
    }

    void RollDropPowerUp()
    {
        float roll = Random.Range(0, 100f);

        if(roll <= powerUpChance)
        {
            int puRoll = Random.Range(0, powerUpPrefs.Count);
            GameObject puInstance = Instantiate(powerUpPrefs[puRoll], transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;
        if (hp <= 0)
        {
            RollDropPowerUp();
            gameObject.SetActive(false);
            HealthManager.Instance.CheckVictory();
            return;
        }

        spriteRenderer.color = hpColors[hp - 1];
    }
}
