using Code.Abstract;
using Code.Abstract.Interfaces;
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
        }
    }
}