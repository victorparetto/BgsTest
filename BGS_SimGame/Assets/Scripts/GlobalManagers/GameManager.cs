using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int currentCoins = 0;

    //Managers
    CanvasManager m_canvas = null;

    void Start()
    {
        m_canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasManager>();
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        m_canvas.coinsText.text = currentCoins.ToString();
    }

    public int GetCurrentCoins()
    {
        return currentCoins;
    }
}
