using System.Collections;
using UnityEngine;


public class DeathBot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystemOne;
    [SerializeField] private ParticleSystem _particleSystemTwo;
    [SerializeField] private GameObject[] _skeleton;
    [SerializeField] private SkinnedMeshRenderer[] _botMesh;

    private bool _bump = false;

    [SerializeField] private float _bumpSpeed = 2.0f;
    private readonly float _bumpValue = 30.0f;
    private readonly float _startValue = 1.0f;
    private float _time;

    public IEnumerator DeathPartical()
    {
        _bump = true;

        yield return new WaitForSeconds(3);
        _particleSystemOne.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        _particleSystemTwo.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        foreach (var item in _skeleton)
        {
            if(item)
            {
                item.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (_bump)
        {
            foreach (var renderer in _botMesh)
            {
                // плавное изменение бэмпа в стандартном шейдере
                renderer.material.SetFloat("_BumpScale", Mathf.Lerp(_startValue, _bumpValue, _time));
                // плавное изменение цвета в стандартном шейдере
                renderer.material.SetColor("_Color", Color.Lerp(Color.white, Color.black, _time));
            }
            _time += Time.deltaTime / _bumpSpeed;
        }
    }
}