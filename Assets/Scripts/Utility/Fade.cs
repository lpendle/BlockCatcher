// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour 
{
	public static Fade use;
	
	public enum EaseType { None, In, Out, InOut }	
	
	void  Awake ()
	{
	    if (use) 
	    {
	     //   Debug.Log("Only one instance of this script in a scene is allowed");
	        return;
	    }
	    
	    use = this;
	}
	
	public IEnumerator Alpha<T>( T obj ,   float start ,   float end ,   float timer  )
	{
	    yield return StartCoroutine(Alpha(obj, start, end, timer, EaseType.None));
	}
	
	public IEnumerator  Alpha<T>( T obj ,   float start ,   float end ,   float timer ,   EaseType easeType  )
	{
	    if (!CheckType(obj)) yield return null;
	        
	    float t = 0.0f;
	    float a = 0.0f;
	    Color c = new Color();
	    
	    if (obj is GUITexture)
        {
            c = (obj as GUITexture).color;	        	
        }
        else
        {
            c = (obj as Material).color;	        	
        }
	    
	    while (t < 1.0f) 
	    {
	        t += Time.deltaTime * (1.0f/timer);
	        if (obj is GUITexture)
	        {
	        	a = Mathf.Lerp(start, end, Ease(t, easeType)) * .5f;
	            (obj as GUITexture).color = new Color(c.r, c.g, c.b, a);	        	
	        }
	        else
	        {
	        	a = Mathf.Lerp(start, end, Ease(t, easeType)) * .5f;
	            (obj as Material).color = new Color(c.r, c.g, c.b, a);        	
	        }

	        yield return 0;
	    }
	}
	
	public IEnumerator  Colors<T> ( T obj ,   Color start ,   Color end ,   float timer  )
	{
	    yield return StartCoroutine(Colors(obj, start, end, timer, EaseType.None));
	}
	
	public IEnumerator  Colors<T> ( T obj ,   Color start ,   Color end ,   float timer ,   EaseType easeType  )
	{
	    if (!CheckType(obj)) yield return null;
	    float t = 0.0f;
	    //T objectType = obj;
	    while (t < 1.0f) {
	        t += Time.deltaTime * (1.0f/timer);
	        if (obj is GUITexture)
	            (obj as GUITexture).color = Color.Lerp(start, end, Ease(t, easeType)) * .5f;
	        else
	            (obj as Material).color = Color.Lerp(start, end, Ease(t, easeType));
	        yield return 0;
	    }
	}
	
	public IEnumerator  Colors<T> ( T obj ,   Color[] colorRange ,   float timer ,   bool repeat  )
	{
	    if (!CheckType(obj)) yield return null;
	    
	    if (colorRange.Length < 2) {
	        Debug.Log("Error: color array must have at least 2 entries");
	        yield return null;
	    }
	    timer /= colorRange.Length;
	    int i = 0;
	    //T objectType = obj;
	    while (true) {
	        float t = 0.0f;
	        while (t < 1.0f) {
	            t += Time.deltaTime * (1.0f/timer);
	            if (obj is GUITexture)
	            {
	                (obj as GUITexture).color = Color.Lerp(colorRange[i], colorRange[(i+1) % colorRange.Length], t) * .5f;	            	
	            }
	            else
	            {
	                (obj as Material).color = Color.Lerp(colorRange[i], colorRange[(i+1) % colorRange.Length], t);	            	
	            }

	            yield return 0;
	        }
	        i = ++i % colorRange.Length;
	        if (!repeat && i == 0) break;
	    }   
	}
	
	private float Ease ( float t ,   EaseType easeType  )
	{
	    if (easeType == EaseType.None)
	        return t;
	    else if (easeType == EaseType.In)
	        return Mathf.Lerp(0.0f, 1.0f, 1.0f - Mathf.Cos(t * Mathf.PI * .5f));
	    else if (easeType == EaseType.Out)
	        return Mathf.Lerp(0.0f, 1.0f, Mathf.Sin(t * Mathf.PI * .5f));
	    else
	        return Mathf.SmoothStep(0.0f, 1.0f, t);
	}
	
	private bool CheckType<T> ( T obj  )
	{
	     if (obj is GUITexture || obj is Material) 
	     {
	        return true;
	     }
	     
	     Debug.Log("Error: object is a " + obj + ". It must be a GUITexture or a Material");
	     return false;
	} 
}