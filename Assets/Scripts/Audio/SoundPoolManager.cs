using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoundPoolManager : MonoBehaviourSingleton<SoundPoolManager>
{
    private Stack<GameObject> sourcesPool;

    protected override void SingletonAwakened()
    {
        sourcesPool = new Stack<GameObject>();
    }
    public void PlaySound(AudioClip clip, float volume, Vector3 location, Transform attachToObject = null)
    {
        if (clip)
        {
            StartCoroutine(PlaySoundRoutine(clip, volume, location, attachToObject));
        }
        else
        {
            Debug.LogWarning("Cannot play a null clip.");
        }
    }
    private IEnumerator PlaySoundRoutine(AudioClip clip, float volume,  Vector3 location, Transform attachToObject)
    {
        if (sourcesPool.Count == 0)
        {
            GameObject temp = new GameObject();
            AudioSource source1 = temp.AddComponent<AudioSource>();
            source1.spatialBlend = 1;
            sourcesPool.Push(temp);
        }
        AudioSource source = sourcesPool.Pop().GetComponent<AudioSource>();
        source.transform.position = location;
        if (attachToObject != null)
        {
            source.transform.SetParent(attachToObject);
        }
        source.PlayOneShot(clip, volume);
        yield return new WaitForSeconds(clip.length);
        source.transform.position = Vector3.zero;
        source.transform.SetParent(gameObject.transform);
        sourcesPool.Push(source.gameObject);
    }

}
