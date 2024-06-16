using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [Range(0.1f, 0.6f)]
    public float coinInterval = 0.2f;

    public List<GameObject> coins;

    void Start()
    {
        foreach (Transform child in transform)
        {
            coins.Add(child.gameObject);
        }
        StartCoroutine(coinChestAnimation());
    }

    IEnumerator coinChestAnimation()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }

    }
}
