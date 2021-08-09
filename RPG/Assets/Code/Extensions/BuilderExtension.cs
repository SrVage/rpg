using UnityEngine;

namespace Code.Extensions
{
    public static class BuilderExtension
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddTrigger(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<BoxCollider>();
            component.isTrigger = true;
            return gameObject;
        }

        public static GameObject AddTrail(this GameObject gameObject, Color color)
        {
            var component = gameObject.GetOrAddComponent<TrailRenderer>();
            component.startColor = color;
            component.endColor = Color.gray;
            component.time = 0.5f;
            component.material = Resources.Load<Material>("TrailMaterial");
            AnimationCurve width = new AnimationCurve();
            width.AddKey(0, 0);
            width.AddKey(0.1f, 1);
            width.AddKey(1, 0);
            component.widthCurve = width;
            return gameObject;
        }

        public static GameObject AddForce(this GameObject gameObject, Vector3 force)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = 0.1f;
            component.useGravity = false;
            component.AddForce(force, ForceMode.Impulse);
            return gameObject;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.GetComponent<T>())
            {
                return gameObject.GetComponent<T>();
            }
            else
                return gameObject.AddComponent<T>();
        }
    }
}