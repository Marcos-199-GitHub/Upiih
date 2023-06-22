using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour{
    public  Text  fpsText;
    private float sum;
    private int   count;

    void Update(){
        sum += 1 / Time.deltaTime;
        count++;
        if( count > 20 ){
            fpsText.text = "FPS: " + Mathf.RoundToInt(sum/count);
            sum          = 0;
            count        = 0;
        }
    }
}