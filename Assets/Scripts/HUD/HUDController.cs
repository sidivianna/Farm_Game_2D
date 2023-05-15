using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image bucketUI;

    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItems playerItems;
    private Player player;

    private void Awake() 
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }

    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    
    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        woodUIBar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        carrotUIBar.fillAmount = playerItems.carrots / playerItems.carrotLimit;
        fishUIBar.fillAmount = playerItems.fishes / playerItems.carrotLimit;

        //toolsUI[player.handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObj) 
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
