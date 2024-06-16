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

        SetCoins(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public int GetCurrentCoins()
    {
        return currentCoins;
    }

    public void SetCoins(int coins)
    {
        currentCoins = coins;
        m_canvas.coinsText.text = currentCoins.ToString();
    }

    public void UpdateCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        m_canvas.coinsText.text = currentCoins.ToString();
    }

}
