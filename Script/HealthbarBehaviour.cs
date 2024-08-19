using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthbarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    void Start()
    {
        Slider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }
}
