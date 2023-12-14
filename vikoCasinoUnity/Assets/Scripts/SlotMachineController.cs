using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class SlotMachineController : MonoBehaviour
{
    public GameObject[] reels; // ������ GameObject ���������
    public Sprite[] symbols; // ������ ���� ��������� �������� ��������
    private Vector3[] initialPositions; // ������ ��� �������� ��������� ������� ���������
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
        // �������������� ������ ��������� �������
        initialPositions = new Vector3[reels.Length];
        for (int i = 0; i < reels.Length; i++)
        {
            // ��������� ��������� ������� ������� ��������
            initialPositions[i] = reels[i].transform.position;
        }
    }

    // ������������ �������� �� ��������� ��������
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
            // �������� ������� ������� �������� � ��� ��������� �������
            reels[i].transform.position = initialPositions[i];
            // ��������������� ������� �� ��������
            RandomizeReel(reels[i]);
            
        }
    }

    public void CheckWin(int r, int p)
    {
        var x = WinningLines(GetSymbolAtPosition(reels[r],p));
        if (x)
        {
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("Lose");
        }
        
    
    }
    
    public bool WinningLines(Sprite firstSymbol)
    {
       
        
        for (int i = 0; i < 3; i++)
        {
            if (GetSymbolAtPosition(reels[i], 0) != firstSymbol)
            {
                   return false;
            }
        }
        return true;
    }


    public Sprite GetSymbolAtPosition(GameObject reel, int position)
    {
        // ������� ���������� �������� � ����� ��������, ����������� ��� last 3 - ��� 0, last 2 - ��� 1 � last 1 - ��� 2
        string[] winningSymbolNames = { "last 1", "last 2", "last 3" };

        if (position < 0 || position >= winningSymbolNames.Length)
        {
            Debug.LogError("Position for GetSymbolAtPosition is out of range.");
            return null;
        }

        // ���� �������� ������ �� �����, ���������������� ����������� �������
        Transform symbolTransform = reel.transform.Find(winningSymbolNames[position]);
        if (symbolTransform == null)
        {
            Debug.LogError("Could not find a symbol at the specified position: " + position);
            return null;
        }

        SpriteRenderer spriteRenderer = symbolTransform.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            return spriteRenderer.sprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer not found on the symbol at position: " + position);
            return null;
        }
    }
}
