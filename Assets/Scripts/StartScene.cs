using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    SceneLoader m_sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        m_sceneLoader = GetComponent<SceneLoader>();
        Destroy(GameObject.Find("Event Logger"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_sceneLoader.LoadNextScene();
        }
    }
}
