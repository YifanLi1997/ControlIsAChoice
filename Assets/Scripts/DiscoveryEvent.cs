using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiscoveryEvent : MonoBehaviour
{
    bool hasOpened = false;
    bool isPanelActive = false;

    [SerializeField] GameObject eventPanel;
    [SerializeField] Sprite sprite_1;
    [SerializeField] Sprite sprite_2;
    [TextArea]
    [SerializeField] string narrative;

    [Header("For Test")]
    [SerializeField] bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (isActivated)
        {
            ActivateThePanel();
        }

        if (isPanelActive)
        {
            // TODO: close
        }
    }

    public void ActivateThePanel()
    {
        eventPanel.SetActive(true);
        isPanelActive = true;
        Image[] images = eventPanel.GetComponentsInChildren<Image>();
        // the first Image is on the panel itself
        images[1].sprite = sprite_1;
        images[2].sprite = sprite_2;
        TextMeshProUGUI textfield = eventPanel.GetComponentInChildren<TextMeshProUGUI>();
        textfield.text = narrative;

        // put the event into log
    }

    public bool GetHasOpened()
    {
        return hasOpened;
    }

    public void SetHasOpened(bool hasOpened)
    {
        this.hasOpened = hasOpened;
    }
}
