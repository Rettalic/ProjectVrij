using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yeet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator timer()
    {

        
        yield return new WaitForSeconds(70);
        SceneManager.LoadScene(1);
    }
}
