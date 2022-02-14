using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoumnMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    private void OnEnable()
    {
        StartCoroutine(EndTime());
    }

    private void Update()
    {
        Moving();
    }

    private IEnumerator EndTime()
    {
        yield return new WaitForSeconds(lifeTime);
        this.gameObject.SetActive(false);
    }

    private void Moving()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

}
