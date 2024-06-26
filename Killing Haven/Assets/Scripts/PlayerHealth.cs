using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, Health, GameReset
{
    [SerializeField] private HealthUI healthUI;
    public static float health;
    private float lerpTimer;
    private float healCooldown;
    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;

    [Header("Damage Overlay")]
    public Image overlay; //our DamageOverlay GameObject
    public float duration; //how long the image stays fully opaque
    public float fadeSpeed; //how quickly the image will fade

    private float durationTimer; //timer to check against the duration
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health,0,maxHealth);
        UpdateHealthUI();
        if(overlay.color.a > 0)
        {
            if (health < 30)
                return;
            durationTimer += Time.deltaTime;
            if(durationTimer > duration)
            {
                //fade the image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }

        if (healCooldown > 0f)
        {
            healCooldown -= 1 * Time.deltaTime;
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if(fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
        if(health <= 0f)
        {
            GameOver();
        }
        healthUI.UpdateHealth(health);
    }

    public void RestoreHealth(float healAmount)
    {
        if (healCooldown <= 0f)
        {
            health += healAmount;
            lerpTimer = 0f;
            healCooldown = 10f;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
        }
        healthUI.UpdateHealth(health);
    }

    private void GameOver()
    {
        UIManager.gameState = GameState.GameOver;
    }

    public void ResetGame()
    {
        health = maxHealth;
        healCooldown = 0f;
        UpdateHealthUI();
        healthUI.UpdateHealth(health);
    }
}
