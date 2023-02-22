using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    private void Awake() {
        offset = new Vector3(0, 0.5f, -1);
    }

    public void SetHPBar(float health){
        slider.value = health;

        HPBarAnimation();
    }
    public void SetHPBar(float health, float max_health){
        slider.maxValue = max_health;

        slider.value = health;
        HPBarAnimation();
    }

    private void HPBarAnimation() {
        slider.fillRect.GetComponent<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = transform.parent.position + offset;
    }
}
