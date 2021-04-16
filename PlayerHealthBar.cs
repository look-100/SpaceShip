using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    public static float healthCurrent;
    public static float healthMax;

    private Image healthBar;
    private Color originalColor;

    void Start()
    {
        healthBar = GetComponent<Image>();
        //healthCurrent = healthMax;
        originalColor = healthBar.color;
    }

    void Update()
    {
        // healthBar.fillAmount = healthCurrent / healthMax;
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, healthCurrent / healthMax, 0.01f);
        if (healthBar.fillAmount <= 0.3f)
        {
            healthBar.color = Color.red;
        }
        else
        {
            healthBar.color = originalColor;
        }
    }
}
