using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowHints : MonoBehaviour
{
    [SerializeField] private float delaytime = 20;
    private TextMeshProUGUI hintText;

    // Start is called before the first frame update
    void Start()
    {
        hintText = gameObject.GetComponent<TextMeshProUGUI>();
        hintText.color = new Color(hintText.color.r, hintText.color.g, hintText.color.b, 0) ;
    }

    // Update is called once per frame
    void Update()
    {
        delaytime -= Time.deltaTime;

        if (delaytime <= 0)
        {
            hintText.color = new Color(hintText.color.r, hintText.color.g, hintText.color.b, 1);
        }
    }
}
