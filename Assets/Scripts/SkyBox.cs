using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Skybox))]

public class SkyBox : MonoBehaviour
{

  [SerializeField] List<Material> _skyboxMaterials;

  Skybox _skybox;

  void Awake()
  {
    _skybox = GetComponent<Skybox>();
  }

  void OnEnable()
  {
    ChangeSkyBox(0);
  }

    void ChangeSkyBox(int skyBox)
    {
      if (_skybox != null && skyBox >= 0 && skyBox <= _skyboxMaterials.Count) 
      {
        _skybox.material = _skyboxMaterials[skyBox];
      }
    }

}
