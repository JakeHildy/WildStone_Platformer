using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciprocatingSpikes : MonoBehaviour
{
    [Tooltip ("Amplitude.")]
    [SerializeField] float amplitude = 1.0f;
    [SerializeField] float period = 1.0f;
    //[SerializeField] float maxPosition = 0.0f;

    private float timePassed = 0f;
    private float initialY;


    private void Start() 
    {
        initialY = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        float frequency = 1 / period;
        float angularFrequency = (2 * Mathf.PI) * frequency;
        float omegaProduct = timePassed * angularFrequency;
        float y = amplitude * Mathf.Sin(omegaProduct);
        //transform.Translate(0, y  Mathf.Sin(timePassed * frequency), 0);
        //Vector3 offset = new Vector3(0, yMove * Mathf.Sin(timePassed * scrollRate), 0);
        transform.localPosition = new Vector3(0, initialY + y, 0);

        timePassed += Time.deltaTime;
    }
}
