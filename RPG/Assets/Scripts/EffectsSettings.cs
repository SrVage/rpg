using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Linq;
using System.Collections;

public class EffectsSettings : MonoBehaviour
{
    private PostProcessVolume _activeVolume;
    private float _time = 0;
    List<PostProcessVolume> postProcessLayer = new List<PostProcessVolume>();
    // Start is called before the first frame update
    void Start()
    {

    }


    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        _time = 0;
        while (_time < 8.0f)
        {
            _activeVolume.profile.GetSetting<ColorGrading>().mixerGreenOutGreenIn.value = Mathf.Lerp(100, 150, _time);
            _activeVolume.profile.GetSetting<ColorGrading>().saturation.value = Mathf.Lerp(0, -8, _time);
            _activeVolume.profile.GetSetting<ColorGrading>().contrast.value = Mathf.Lerp(0, -12, _time);
            _time += Time.deltaTime;
            yield return null; 
        }
        _activeVolume.profile.GetSetting<ColorGrading>().mixerGreenOutGreenIn.value = 150;
        _activeVolume.profile.GetSetting<ColorGrading>().saturation.value = -8;
        _activeVolume.profile.GetSetting<ColorGrading>().contrast.value = -12;

    }

    IEnumerator ChangeColorBack()
    {
        yield return new WaitForSeconds(0.5f);
        _time = 0;
        while (_time < 8.0f)
        {
            _activeVolume.profile.GetSetting<ColorGrading>().mixerGreenOutGreenIn.value = Mathf.Lerp(150, 100, _time);
            _activeVolume.profile.GetSetting<ColorGrading>().saturation.value = Mathf.Lerp(-8, 0, _time);
            _activeVolume.profile.GetSetting<ColorGrading>().contrast.value = Mathf.Lerp(-12, 0, _time);
            _time += Time.deltaTime;
            yield return null;
        }
        _activeVolume.profile.GetSetting<ColorGrading>().mixerGreenOutGreenIn.value = 100;
        _activeVolume.profile.GetSetting<ColorGrading>().saturation.value = 0;
        _activeVolume.profile.GetSetting<ColorGrading>().contrast.value = 0;

    }

    // Update is called once per frame
    public void EnterMoor()
    {
        PostProcessManager.instance.GetActiveVolumes(GetComponent<PostProcessLayer>(), postProcessLayer);
        _activeVolume = postProcessLayer.First();
            StartCoroutine("ChangeColor");
    }

    public void ExitMoor()
    {
        PostProcessManager.instance.GetActiveVolumes(GetComponent<PostProcessLayer>(), postProcessLayer);
        _activeVolume = postProcessLayer.First();
        StartCoroutine("ChangeColorBack");
    }
}
