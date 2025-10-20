using UnityEngine.UI;
using UnityEngine;

public class LerpAlpha : MonoBehaviour
{
    public void Fade(Image imgToLerp, float time, bool fadeInIsTrueAndFadeOutIsFalse)
    {
        imgToLerp.CrossFadeAlpha(255, time, fadeInIsTrueAndFadeOutIsFalse);
    }
}
