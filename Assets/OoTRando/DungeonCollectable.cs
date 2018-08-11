using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DungeonCollectable : MonoBehaviour, IPointerClickHandler
{
    public Sprite Unknown;
    public Sprite EmeraldDungeon;
    public Sprite RubyDungeon;
    public Sprite SapphireDungeon;
    public Sprite ForestMedalion;
    public Sprite FireMedalion;
    public Sprite WaterMedalion;
    public Sprite SpiritMedalion;
    public Sprite ShadowMedalion;
    public Sprite LightMedalion;

    public enum DungeonState
    {
        Unknown,
        Emerald,
        Ruby,
        Sapphire,
        Forest,
        Fire,
        Water,
        Spirit,
        Shadow,
        Light
    }

    public DungeonState CurrentDungeonState = DungeonState.Unknown;

    protected Image displayImage;
    protected Button selfButton;

    public bool ItemAcquired;
    public bool ItemIgnored;
    public bool IsFree;

    // Use this for initialization
    void Awake()
    {
        displayImage = GetComponent<Image>();
        selfButton = GetComponent<Button>();
        selfButton.interactable = IsFree;
        ItemAcquired = IsFree;
        displayImage.sprite = Unknown;
        CurrentDungeonState = DungeonState.Unknown;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            leftClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick();
        }
    }

    protected void leftClick()
    {
        ItemAcquired = !ItemAcquired || IsFree;
        selfButton.interactable = !selfButton.interactable || IsFree;
    }

    protected void rightClick()
    {
        switch (CurrentDungeonState)
        {
            case DungeonState.Unknown:
                CurrentDungeonState = DungeonState.Emerald;
                displayImage.sprite = EmeraldDungeon;
                break;
            case DungeonState.Emerald:
                CurrentDungeonState = DungeonState.Ruby;
                displayImage.sprite = RubyDungeon;
                break;
            case DungeonState.Ruby:
                CurrentDungeonState = DungeonState.Sapphire;
                displayImage.sprite = SapphireDungeon;
                break;
            case DungeonState.Sapphire:
                CurrentDungeonState = DungeonState.Forest;
                displayImage.sprite = ForestMedalion;
                break;
            case DungeonState.Forest:
                CurrentDungeonState = DungeonState.Fire;
                displayImage.sprite = FireMedalion;
                break;
            case DungeonState.Fire:
                CurrentDungeonState = DungeonState.Water;
                displayImage.sprite = WaterMedalion;
                break;
            case DungeonState.Water:
                CurrentDungeonState = DungeonState.Spirit;
                displayImage.sprite = SpiritMedalion;
                break;
            case DungeonState.Spirit:
                CurrentDungeonState = DungeonState.Shadow;
                displayImage.sprite = ShadowMedalion;
                break;
            case DungeonState.Shadow:
                CurrentDungeonState = DungeonState.Light;
                displayImage.sprite = LightMedalion;
                break;
            case DungeonState.Light:
                CurrentDungeonState = DungeonState.Unknown;
                displayImage.sprite = Unknown;
                break;
        }
    }    
}
