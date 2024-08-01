using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScript : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;
    
    private float amount;
    IEnumerator Start()
    {
        while(amount <= 100)
        {
            int speed = Random.Range(10, 100);
            amount += speed * Time.deltaTime;
            loadingSlider.value = amount;
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
