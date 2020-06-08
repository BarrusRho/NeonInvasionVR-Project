using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletUpdater : MonoBehaviour
{
    private TextMeshProUGUI bulletText;

    private int maxNumberOfBullets;



    // Start is called before the first frame update
    void Start()
    {
        bulletText = GetComponent<TextMeshProUGUI>();

        maxNumberOfBullets = 100;
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = maxNumberOfBullets.ToString();

        maxNumberOfBullets--;
    }
}
