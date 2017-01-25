using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallLevelParentRemover : MonoBehaviour
{

    [SerializeField] GameObject img;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "wall")
        {
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;
            StartCoroutine(asd());
        }
    }


    IEnumerator asd()
    {
        img.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level 5 - Wall");

    }
}
