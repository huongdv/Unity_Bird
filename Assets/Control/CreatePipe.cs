using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createPipe());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator createPipe(){
        yield return new WaitForSeconds(3);
        Vector3 pos_tmp = pipeHolder.transform.position;
        pos_tmp.y = Random.Range(-2.0f, 2.0f);
        Instantiate(pipeHolder, pos_tmp, Quaternion.identity);
        StartCoroutine(createPipe());
    }

}
