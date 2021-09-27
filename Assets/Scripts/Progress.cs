using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    public int _coins;
    public int _maxCoins;


    private void Start()
    {
        _maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    public void AddCoins()
    {
        _coins++;

        if (_coins >= _maxCoins)
        {
            Killer();
            Reloader();
        }    
    }

    void Killer()
    {
        GameObject[] target = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < target.Length; i++)
        {
            Destroy(target[i]);
        }
    }
    
    public void Reloader()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
