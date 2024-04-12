using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptTextH;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateHealth(float health)
    {
        promptTextH.text = $"{health} / 100";
        //Debug.Log("update health");
    }
}
