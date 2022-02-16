using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDelay : MonoBehaviour
{
    public float amount = 0.02f;
    public float maxAmount = 0.03f;
    public float smooth = 3f;
    private Vector3 initPosition;
    private Vector3 def;

    void Start()
    {
        initPosition = transform.localPosition;
        def = transform.localPosition;
    }

    void FixedUpdate()
    {

        DelayGun();
    }

    void DelayGun()
    {
        float factorX = -Input.GetAxis("Mouse X") * amount;
        float factorY = -Input.GetAxis("Mouse Y") * amount;

        if (factorX > maxAmount)
            factorX = maxAmount;
        
        if (factorX < -maxAmount)
            factorX = -maxAmount;

        if (factorY > maxAmount)
            factorY = maxAmount;

        if (factorY < -maxAmount)
            factorY = -maxAmount;

        Vector3 Final = new Vector3(def.x + factorX, def.y + factorY, def.z);
        transform.localPosition = Vector3.Lerp(transform.localPosition, Final, Time.deltaTime * smooth);
    }
}
