using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterHealthbarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Slider;
    public Color low;
    public Color high;
    public Vector3 offset;
    public bool once;
    public bool then;
    public TextMeshProUGUI healthText;

    void Start()
    {
        Slider.gameObject.SetActive(true);
        once = true;
        if (once)
        {
            Slider.fillRect.GetComponentInChildren<Image>().color = Color.green;
            once = false;
        }
        }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetHealth(float health, float maxHealth)
    {
        //Slider.gameObject.SetActive(health < maxHealth);
        //Slider.value = health;
        Slider.value = health;
        Slider.maxValue = maxHealth;
        if(health < 0)
        {
            health = 0;
            healthText.text = $"{health} / {maxHealth}";

        }
        healthText.text = $"{health} / {maxHealth}";
        if (then) { 
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }
    }
}
