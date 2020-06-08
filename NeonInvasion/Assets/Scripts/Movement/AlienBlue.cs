using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBlue : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionEffectPrefab;

    private UIManager uiManager;

    private bool hasEntered;

    [SerializeField]
    private GameObject floatingText;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBullet") && !hasEntered)
        {
            hasEntered = true;

            uiManager.IncreaseScoreForBullets();

            Instantiate(explosionEffectPrefab, transform.position, transform.rotation);

            ShowFloatingText();

            Destroy(this.gameObject, 0f);

            Destroy(transform.parent.gameObject, 0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueBullet") && hasEntered == true)
        {
            hasEntered = false;
        }
    }

    void ShowFloatingText()
    {
        Instantiate(floatingText, transform.position, Quaternion.identity);
    }
}
