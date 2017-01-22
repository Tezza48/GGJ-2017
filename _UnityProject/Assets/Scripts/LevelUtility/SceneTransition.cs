using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public float distance = 2;

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
        if (Vector3.Distance(transform.position, player.transform.position) < distance && isActive)
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
