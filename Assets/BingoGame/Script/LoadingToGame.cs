using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loading1());
    }

    // Update is called once per frame
    IEnumerator Loading1()
    {

        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadScene("MenuScene");
    }
}
