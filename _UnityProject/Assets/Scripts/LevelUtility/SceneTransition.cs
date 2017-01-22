using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {


    GameObject player;
    bool isActive = true;

    [SerializeField] GameObject fadeIn;
    [SerializeField] string sceneName;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 0.8 && isActive)
        {
            fadeIn.gameObject.SetActive(true);
            isActive = false;
            StartCoroutine(ChangeScene());
        }

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }

}
