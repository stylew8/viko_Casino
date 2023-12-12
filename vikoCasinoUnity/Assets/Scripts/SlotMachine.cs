﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public int money;
    public Text moneyText;
    public int price;
    public Slot[] slots;
    public Combinations[] combinations;
    public float timeInterval = 0.025f;
    private int stoppedSlots = 3;
    private bool isSpin = false;
    public bool isAuto;
    public Animator btnAnim;

    private void Start()
    {
        btnAnim = GameObject.FindGameObjectWithTag("AutoButton").GetComponent<Animator>();
    }

    public void Spin()
    {
        if (!isSpin && money - price >= 0)
        {
            ChangeMoney(-price);
            isSpin = true;
            foreach (Slot i in slots)
            {
                i.StartCoroutine("Spin");
            }
        }
    }

    public void WaitResults()
    {
        stoppedSlots -= 1;
        if(stoppedSlots <= 0)
        {
            stoppedSlots = 3;
            CheckResults();
        }
    }

    public void CheckResults()
    {
        isSpin = false;
        foreach (Combinations i in combinations)
        {
            Debug.Log(slots[0].gameObject.GetComponent<Slot>().stoppedSlot.ToString());
            Debug.Log(i.FirstValue.ToString());
            if (slots[0].gameObject.GetComponent<Slot>().stoppedSlot.ToString() == i.FirstValue.ToString()
                && slots[1].gameObject.GetComponent<Slot>().stoppedSlot.ToString() == i.SecondValue.ToString()
                && slots[2].gameObject.GetComponent<Slot>().stoppedSlot.ToString() == i.ThirdValue.ToString())
            {
                ChangeMoney(i.prize);
            }
        }
        if (isAuto)
        {
            Invoke("Spin", 0.4f);
        }
    }
    public void OnlyVictory()
    {
        if (!isSpin && money - price >= 0)
        {
            ChangeMoney(-price);
            isSpin = true;
            SlotValue randItem = (SlotValue)Random.Range(0, 5);
            foreach (Slot i in slots)
            {
                i.randItem = randItem;
                i.StartCoroutine("CheatSpin");
            }
        }
    }
    private void ChangeMoney(int count)
    {
        money += count;
        moneyText.text = money.ToString();
    }
    public void SetAuto()
    {
        if (!isAuto)
        {
            timeInterval = timeInterval / 10;
            isAuto = true;
            btnAnim.SetBool("isAuto", true);
            Spin();
        }
        else
        {
            timeInterval = timeInterval * 10;
            isAuto = false;
            btnAnim.SetBool("isAuto", false);
        }
    }
}

[System.Serializable]
public class Combinations
{
    public enum SlotValue
    {
        Crown,
        Diamond,
        Seven,
        Cherry,
        Bar
    }

    public SlotValue FirstValue;
    public SlotValue SecondValue;
    public SlotValue ThirdValue;
    public int prize;
}
