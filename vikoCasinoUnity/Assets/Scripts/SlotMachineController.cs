using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineController : MonoBehaviour
{
    public GameObject[] reels; // Массив GameObject барабанов
    public Sprite[] symbols; // Массив всех возможных спрайтов символов
    private Vector3[] initialPositions; // Массив для хранения начальных позиций барабанов
    // Вызывается для начала вращения и рандомизации барабанов
    public void SpinReels()
    {
        foreach (GameObject reel in reels)
        {
            RandomizeReel(reel);
        }
        
        // Здесь можно добавить логику для начала вращения барабанов
    }

    public void Start()
    {
        foreach (GameObject reel in reels)
        {
            RandomizeReel(reel);
        }
        // Инициализируем массив начальных позиций
        initialPositions = new Vector3[reels.Length];
        for (int i = 0; i < reels.Length; i++)
        {
            // Сохраняем начальную позицию каждого барабана
            initialPositions[i] = reels[i].transform.position;
        }
    }

    // Рандомизация символов на отдельном барабане
    public void RandomizeReel(GameObject reel)
    {
        foreach (Transform symbol in reel.transform)
        {
            int randomIndex = Random.Range(0, symbols.Length);
            Sprite selectedSprite = symbols[randomIndex];

            Vector3 newPosition = symbol.transform.position;
            newPosition.z = -2;

            symbol.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            symbol.transform.position = newPosition;
        }
    }

    public void ResetReels()
    {
        
        for (int i = 0; i < reels.Length; i++)
        {
            // Сбросить позицию каждого барабана в его начальную позицию
            reels[i].transform.position = initialPositions[i];
            // Рандомизировать символы на барабане
            RandomizeReel(reels[i]);
        }
    }
}
