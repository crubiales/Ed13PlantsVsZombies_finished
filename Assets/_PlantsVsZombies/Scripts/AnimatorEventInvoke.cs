using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnAnimatorEvent : UnityEvent { }


public class AnimatorEventInvoke : MonoBehaviour
{
  public OnAnimatorEvent animatorEvent;

  public void Invoke()
  {
    if (animatorEvent != null) animatorEvent.Invoke();   
  }

}
