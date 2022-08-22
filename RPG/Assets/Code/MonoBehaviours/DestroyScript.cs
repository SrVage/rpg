using Code.Abstract;
using Code.Abstract.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace Code.MonoBehaviours
{
    public class DestroyScript:MonoBehaviour, IDestroy
    {
        public void Destroy()
        {
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<TriggerListener>());
            Destroy(GetComponent<EntityRef>());
            Destroy(GetComponent<Animator>());
            GetComponent<Rigidbody>().isKinematic = false;
            DOTween.Sequence().AppendInterval(5f).Append(transform.DOScale(0.1f, 2f).OnComplete(()=>Destroy(gameObject)));
        }
    }
}