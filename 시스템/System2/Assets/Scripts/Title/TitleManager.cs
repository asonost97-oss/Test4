using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public Animation logoAnim;
    public TextMeshProUGUI logoTxt;

    public GameObject title;

    private void Awake()
    {
        logoAnim.gameObject.SetActive(true);
        title.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(LogoPlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
