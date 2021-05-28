using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permite que un audioClip pueda ser ejecutado durante el estado de animación.
/// </summary>
public class PlayAudioClip : StateMachineBehaviour
{
    //Declaración variables
    public float t = 0.5f;
    public float modulus = 0f;

    /// <summary>
    /// AudioClip a ser ejecutado.
    /// </summary>
    public AudioClip clip;
    float last_t = -1f;

    //Método para hacer delay del clip de audio
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var nt = stateInfo.normalizedTime;
        if (modulus > 0f) nt %= modulus;
        if (nt >= t && last_t < t)
            AudioSource.PlayClipAtPoint(clip, animator.transform.position);
        last_t = nt;
    }
}
