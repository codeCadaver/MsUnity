using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityLogo : MonoBehaviour
{
    public bool bFaceCamera = true;
    public float rotationSpeed = 10f;
    public float radianDelta = 30f;

    private Vector3 _newRotation;

    // Start is called before the first frame update
    void Start()
    {
        _newRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FaceCamera()
    {
        if (bFaceCamera)
        {
            transform.localEulerAngles = Vector3.RotateTowards(this.transform.position, Camera.main.transform.position, radianDelta, rotationSpeed);
        }
    }

    void ManualBillboard()
    {
        //_newRotation.x = Camera.main.transform.rotation.x - 180;
        _newRotation.x = 180 - Camera.main.transform.rotation.x;
        _newRotation.y = 180 - Camera.main.transform.rotation.y;



        transform.localEulerAngles = _newRotation;
    }
}
