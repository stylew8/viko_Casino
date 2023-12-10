using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineController : MonoBehaviour
{
    public GameObject[] reels; // ������ GameObject ���������
    public Sprite[] symbols; // ������ ���� ��������� �������� ��������

    // ���������� ��� ������ �������� � ������������ ���������
    public void SpinReels()
    {
        foreach (GameObject reel in reels)
        {
            RandomizeReel(reel);
        }
        // ����� ����� �������� ������ ��� ������ �������� ���������
    }

    public void Start()
    {
        foreach (GameObject reel in reels)
        {
            RandomizeReel(reel);
        }
    }

    // ������������ �������� �� ��������� ��������
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
