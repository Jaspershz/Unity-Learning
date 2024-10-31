using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private PlayerAttributeManager attributeManager;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = attributeManager.getEXPPercentage();
    }
}
