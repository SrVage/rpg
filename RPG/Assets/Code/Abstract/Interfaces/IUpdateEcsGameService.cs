using UnityEngine;

namespace Code.Abstract.Interfaces
{
    public interface IUpdateEcsGameService
    {
        void Update();
        void Destroy(GameObject gameObject);
    }
}