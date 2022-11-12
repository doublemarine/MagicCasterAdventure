using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicText : MonoBehaviour
{
    public string[] magic;
    private Text magicText;

    // Start is called before the first frame update
    void Start()
    {
        magicText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        magicText.text = "「" + magic[GManager.instance.level-1] + "」" + "を覚えた！";
    }
}
