using UnityEngine;

public class CloneEnvironment : MonoBehaviour
{
    public GameObject environment;
    public int columns = 2;
    public float verticalSpace = 30.0f;
    public int rows = 2;
    public float horizontalSpace = 30.0f;

    private void Awake(){
        for (var i = 0; i < columns; i++)
        {
            for (var j = 0; j < rows; j++)
            {
                if (i == 0 & j == 0) continue;
                Instantiate(environment, new Vector3(i * verticalSpace, 0.0f, j * horizontalSpace), Quaternion.identity);
            }
        }
    }
}
