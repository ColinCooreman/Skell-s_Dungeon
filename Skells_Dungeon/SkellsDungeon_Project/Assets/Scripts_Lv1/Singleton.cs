using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //fields
    private static T _Instance = null;
    //private static object _lock = new object();
    private static bool _isApplicationQuitting = false;

    //methods
    public static T Instance()
    {
        if (_isApplicationQuitting)
        {
            return null;
        }
        if (_Instance == null)
        {
            //find object in scene
            _Instance = FindObjectOfType(typeof(T)) as T;
            if(_Instance == null)
            {
                GameObject singleton = new GameObject(typeof(T).ToString());
                _Instance = singleton.AddComponent<T>();
                //flag to not be destroyed on load
                DontDestroyOnLoad(singleton);
            }
        }
        return _Instance;
    }
}
