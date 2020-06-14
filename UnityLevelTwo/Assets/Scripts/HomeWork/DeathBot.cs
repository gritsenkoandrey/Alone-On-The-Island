using System.Collections;
using UnityEngine;


public sealed class DeathBot : BaseObjectScene/*, IExecute*/
{
    #region Fields

    [SerializeField] private ParticleSystem _particleSystemOne;
    [SerializeField] private ParticleSystem _particleSystemTwo;
    [SerializeField] private GameObject[] _skeleton;
    [SerializeField] private SkinnedMeshRenderer[] _botMesh;

    private bool _bump;

    [SerializeField] private float _bumpSpeed = 2.0f;
    private readonly float _bumpValue = 30.0f;
    private readonly float _startValue = 1.0f;
    private float _time;

    #endregion


    #region UnityMethods

    public void Update()
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

    #endregion


    #region Methods

    public IEnumerator DeathPartical()
    {
        _bump = true;

        yield return new WaitForSeconds(1);
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

    //public bool IsBump(bool bump)
    //{
    //    return _bump = bump;
    //}

    //public void Execute()
    //{
    //    if (_bump)
    //    {
    //        foreach (var renderer in _botMesh)
    //        {
    //            renderer.material.SetFloat("_BumpScale", Mathf.Lerp(_startValue, _bumpValue, _time));
    //            renderer.material.SetColor("_Color", Color.Lerp(Color.white, Color.black, _time));
    //        }
    //        _time += Time.deltaTime / _bumpSpeed;
    //    }
    //}

    #endregion
}