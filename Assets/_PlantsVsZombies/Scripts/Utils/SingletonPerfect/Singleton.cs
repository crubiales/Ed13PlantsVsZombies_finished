using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Singleton<T> {

    /*
	This is required in every script that inherits from Singleton for it to work properly:
	
	:: First, Inherit from Singleton class like so,
	public class YOURTYPE : Singleton<YOURTYPE> {}
	
	:: Second, include this variable so you can access the instance of your singleton.
	public static YOURTYPE Instance {
		get {
			return ((YOURTYPE)mInstance);
		} set {
			mInstance = value;
		}
	}
	
	:: Third, Voila! Now you can access the instance of your singleton with YOURTYPE.Instance
	*/

    public static string singletonHolder = "SINGLETON";
	
	protected static Singleton<T> mInstance {
		get {
			if(!_mInstance)
			{
				T [] managers = GameObject.FindObjectsOfType<T>();
                
				if(managers.Length != 0)
				{
					if(managers.Length == 1)
					{
                        // If we find ONE manager BUT we have the 
                        // _mInstance already initialized, it means
                        // we have already created a singleton
                        // and it is in the "DontDestroyOnLoad"
                        // scene, so we destroy this one!
                        if (_mInstance != null)
                        {
                            Debug.LogError("You had already one Singleton");

                            foreach (T manager in managers)
                            {
                                Destroy(manager.gameObject);
                            }
                        } else
                        {
                            // if the _mInstance is null, then this
                            // is really the first time we call it,
                            // so let's make it a singleton
                            _mInstance = managers[0];
                            _mInstance.gameObject.name = typeof(T).Name;
                            MakeSingletonPersistent(_mInstance.gameObject);
                        }                       
                        
                        return _mInstance;
					} else {
						Debug.LogError("You have more than one " + typeof(T).Name + " in the scene. You only need 1, it's a singleton!");
						foreach(T manager in managers)
						{
							Destroy(manager.gameObject);
						}
					}
				}
				GameObject gO = new GameObject(typeof(T).Name, typeof(T));
				_mInstance = gO.GetComponent<T>();
                
                MakeSingletonPersistent(_mInstance.gameObject);



            }
			return _mInstance;
		} set {
			_mInstance = value as T;
		}
	}
	private static T _mInstance;


    /// <summary>
    /// Ensures the gameObject that has the singleton isn't
    /// destroyed on load, AND
    /// Creates (if necessary) the holder GameObject
    /// 
    /// </summary>
    /// <param name="gO"></param>
    private static void MakeSingletonPersistent(GameObject gO)
    {
        /// First, we make sure the current singleton holder
        /// isn't destroyed on load
        
        /// Then, we find the holder (or create one)
        GameObject holder = GameObject.Find(singletonHolder);

        if (holder == null)
        {
            holder = new GameObject(singletonHolder);
        }

        DontDestroyOnLoad(holder);

        /// finally, we set the current gameObject has child
        /// of the holder
        gO.transform.SetParent(holder.transform);     
        
    }
}
