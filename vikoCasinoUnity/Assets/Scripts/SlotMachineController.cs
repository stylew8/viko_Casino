using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineController : MonoBehaviour
{
    public GameObject[] reels; // Массив GameObject барабанов
    public Sprite[] symbols; // Массив всех возможных спрайтов символов
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
    }

    // Рандомизация символов на отдельном барабане
    private void RandomizeReel(GameObject reel)
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
}
