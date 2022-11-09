using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTimer : MonoBehaviour
{
    [SerializeField]
    private float _delayBeforeNewScene = 10f;

    [SerializeField]
    private string _sceneNameToLoad;
    private float _timeElapsed;

    private void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _delayBeforeNewScene)
        {
            SceneManager.LoadScene(_sceneNameToLoad);
        }
    }
}
