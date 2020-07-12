using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiscoveryEvent : MonoBehaviour
{
    bool hasOpened = false;
    bool isPanelActive = false;

    [Tooltip("only needed for the key")]
    [SerializeField] Player optionalPlayer;
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
        if (!eventPanel)
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            eventPanel = canvas.transform.Find("Panel").gameObject;
        }

        // for quick test
        if (isActivated)
        {
            ActivateThePanel();
        }

        if (isPanelActive)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Time.timeScale = 1;
                eventPanel.SetActive(false);
                isPanelActive = false;
                if (gameObject.CompareTag("Key"))
                {
                    optionalPlayer.LevelUp();
                }
            }
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

    public bool GetIsPanelActive()
    {
        return isPanelActive;
    }

    public bool GetHasOpened()
    {
        return hasOpened;
    }

    public string GetNarrative()
    {
        return narrative;
    }

    public void SetHasOpened(bool hasOpened)
    {
        this.hasOpened = hasOpened;
    }
}
