using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SusMeterManager : MonoBehaviour
{

    public Image susMeter;
    public float susAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateSusAmount(float amount)
    {
        susAmount += amount;
        susAmount = Mathf.Clamp(susAmount, 0, 100);

        susMeter.fillAmount = susAmount / 100f;
    }
}
