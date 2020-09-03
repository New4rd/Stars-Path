using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomoveCamera : MonoBehaviour
{
    static private AutomoveCamera _inst;
    static public AutomoveCamera Inst
    {
        get { return _inst; }
    }

    private Vector3 rotation;

    public float speed;
    public float rotationSpeed;


    private void Awake()
    {
        _inst = this;
        rotation = new Vector3(0,0,rotationSpeed);
    }


    private void Start()
    {
        //StartCoroutine(SwitchCameraRotation());
    }


    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z + speed * Time.deltaTime);

        transform.Rotate(rotation);
    }


    private IEnumerator SwitchCameraRotation ()
    {
        yield return new WaitForSecondsRealtime(2.22f);
        rotation = new Vector3(0, 0, -rotation.z);
        StartCoroutine(SwitchCameraRotation());
    }
}
