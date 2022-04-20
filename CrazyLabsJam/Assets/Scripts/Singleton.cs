using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> {
    private static T _instance;
    public static T Instance { get { return _instance; } }

    public virtual void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = (T)this;
            
        }
    }
}