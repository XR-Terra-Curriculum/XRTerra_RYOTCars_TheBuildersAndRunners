using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUtility : MonoBehaviour
{
    public static VRUtility Instance;

    public AudioSource PlaySpatialClipAt(AudioClip clip, Vector3 pos, float volume, float spatialBlend = 1f, float randomizePitch = 0)
    {

        if (clip == null)
        {
            return null;
        }

        GameObject go = new GameObject("SpatialAudio - Temp");
        go.transform.position = pos;

        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;

        // Currently only Oculus Integration supports spatial audio
#if OCULUS_INTEGRATION
            source.spatialize = true;
#endif
        //source.pitch = randomizePitch;
        source.spatialBlend = spatialBlend;
        source.volume = volume;
        source.Play();

        Destroy(go, clip.length);

        return source;
    }

}
