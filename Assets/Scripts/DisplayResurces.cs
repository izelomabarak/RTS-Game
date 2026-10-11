using UnityEngine;
using TMPro;
public class DisplayResurces : MonoBehaviour
{
    public TMP_Text resourcesTextRed;
    public TMP_Text resourcesTextGray;
    void Update()
    {
        GameObject baseRed = GameObject.FindGameObjectWithTag("BaseRed");
        BaseElements baseResurcesRed = baseRed.GetComponent<BaseElements>();
        resourcesTextRed.text = "Red Resurces: " + baseResurcesRed.resurces;
        GameObject baseGray = GameObject.FindGameObjectWithTag("BaseGray");
        BaseElements baseResurcesGray = baseGray.GetComponent<BaseElements>();
        resourcesTextGray.text = "Red Resurces: " + baseResurcesGray.resurces;
    }
}
