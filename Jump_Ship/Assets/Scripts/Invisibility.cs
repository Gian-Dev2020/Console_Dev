using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public Material defaultSkin;
    public Material invisibleSkin;

    public bool detectable;

    public GameObject player;

    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = player.GetComponent<MeshRenderer>();
        defaultSkin = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            meshRenderer.material = invisibleSkin;
        }
    }
}
