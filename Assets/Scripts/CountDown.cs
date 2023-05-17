using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    [SerializeField] float duration;
    [SerializeField] Image coolDown;
    void Start()
    {
        coolDown.fillAmount = 0;
    }


    void Update()
    {
        Timer();
    }
    void Timer()
    {
        if (Movement.dashed)
        { 
            duration -= Time.deltaTime;
            coolDown.fillAmount = Mathf.InverseLerp(2.5f, 0, duration);

        }
        else 
        {
            coolDown.fillAmount = 0;
            duration = 2.5f;
        }
    }

}
