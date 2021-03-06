using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    public int hits=1;
    public int points=10;
    public Vector3 rotator;
    public Material hitMaterial;

    Material _orgMaterial;
    Renderer _renderer;
    void Start()
    {
      transform.Rotate(rotator*(transform.position.x + transform.position.y));
      _renderer= GetComponent<Renderer>();
      _orgMaterial= _renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(rotator*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        GameManager.Instance.Score += points;
        if(hits <=0)
        {
            Destroy(gameObject);
        }
        _renderer.sharedMaterial= hitMaterial;
        Invoke("RestorMaterial", 0.5f);
    }
    void RestorMaterial()
    {
        _renderer.sharedMaterial= _orgMaterial;
    }
}
