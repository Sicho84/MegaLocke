using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] heartSprites;

    public Image heartUI;

    private GameObject player;

    private PlayerStatus playerStatus;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();


    }

    void Update()
    {
            heartUI.sprite = heartSprites[playerStatus.currentHealth];
        
    }


}
