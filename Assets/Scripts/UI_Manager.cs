using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Button startServerButton;

    [SerializeField]
    private Button startHostButton;

    [SerializeField]
    private Button startClientButton;

    private void Awake()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
    }

    private void Start()
    {
        startHostButton.onClick.AddListener(() => 
        {
            if(NetworkManager.Singleton.StartHost())
            {
                Debug.Log("Host started...");
            }
            else
            {

                Debug.Log("Host could not be started.");
            }
        });

        startServerButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartServer())
            {
                Debug.Log("Server started...");
            }
            else
            {

                Debug.Log("Server could not be started.");
            }
        });

        startClientButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartClient())
            {
                Debug.Log("Client started...");
            }
            else
            {

                Debug.Log("Client could not be started.");
            }
        });
    }
}
