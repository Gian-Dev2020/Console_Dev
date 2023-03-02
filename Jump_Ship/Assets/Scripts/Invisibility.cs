using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public GameObject player;
    public Material defaultSkin;
    public Material invisibleSkin;

    SkinnedMeshRenderer meshRenderer;
    //MeshRenderer meshRenderer;

    public static bool detectable;
    bool timerStarted;

    float invisibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = player.GetComponent<SkinnedMeshRenderer>();
        defaultSkin = meshRenderer.material;

        detectable = true;
        timerStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            detectable = false;
            meshRenderer.material = invisibleSkin;
            timerStarted = true;
        }
        if (timerStarted)
        {
            AbilityReset();
        }
    }

    void AbilityReset()
    {
        invisibleTimer += Time.deltaTime;
        //Debug.Log(invisibleTimer);

        if (invisibleTimer > 5.0f)
        {
            detectable = true;
            meshRenderer.material = defaultSkin;
            invisibleTimer = 0.0f;
            timerStarted = false;
        }
    }
}