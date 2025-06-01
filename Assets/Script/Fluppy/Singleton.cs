using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
   private static T instance;

   public static T Instance
   {
        get
        {
            if (instance == null)
            {
                instance = new GameObject(nameof(T)).AddComponent<T>();
            }
            return instance;
        }
   }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
        }

        DontDestroyOnLoad(this);
    }
}
