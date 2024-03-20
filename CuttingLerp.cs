using UnityEngine;
using UnityEngine.UI;

public class CuttingLerp : MonoBehaviour
{
    public float cuttingTime = 10f; 
    public Slider progressBar;

    private bool isCutting = false;

    void Start()
    {

        if (progressBar == null)
        {
            Debug.LogError("Progress Bar not assigned!");
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isCutting)
        {
            StartCoroutine(CutVegetable());
        }
    }

    IEnumerator CutVegetable()
    {
        isCutting = true;

        float elapsedTime = 0f;

        while (elapsedTime < cuttingTime)
        {

            float progress = Mathf.Lerp(0f, 1f, elapsedTime / cuttingTime);
            UpdateProgressBar(progress);

            elapsedTime += Time.deltaTime;
            yield return null;
        }



        isCutting = false;
    }

    void UpdateProgressBar(float progress)
    {

        progressBar.value = progress;
    }
}
