
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

using utils.hidden;
using utils.math;

namespace utils
{


    public class pools : MonoBehaviour
    {

        static pools _instLocal;
        static pools inst
        {
            get
            {
                if (_instLocal == null) _instLocal = new GameObject("pools").AddComponent<pools>();

                return _instLocal;

            }
        }







        #region  TEXT POOL
        [SerializeField] TMPro.TextMeshProUGUI textTemplate;
        foivosPool<TMPro.TextMeshProUGUI> textsPool { get; set; } =
              new()
              {
                  Instantiate = () =>
                  {
                      //"NEW TEXT IN POOL".logError();
                      var t = Instantiate(inst.textTemplate) as TMPro.TextMeshProUGUI;
                      t.transform.parent = inst.textTemplate.transform.parent;
                      t.gameObject.SetActive(true);
                      t.enabled = false;
                      return t;
                  },
                  Initialize = t =>
                  {
                      // "GIVE TEXT IN POOL".logError();
                      t.enabled = true;
                      t.transform.localScale = Vector3.one;
                      t.transform.eulerAngles = Vector3.zero;
                      t.color = Color.white;

                  },
                  Deactivate = t =>
                  {
                      //"RETURN TEXT IN POOL".logError();
                      t.enabled = false;
                  },
              };
        static TMPro.TextMeshProUGUI GetText()
        {
            return inst.textsPool.Get();
        }
        static void returnMe(TMPro.TextMeshProUGUI t)
        {
            inst.textsPool.Remove(t);
        }

        #endregion


        #region  SPRITE POOL
        //[SerializeField] SpriteRenderer spriteTemplate;
        foivosPool<SpriteRenderer> spritePool { get; set; } =
              new()
              {
                  Instantiate = () =>
                  {
                      var g = new GameObject("Sprite");
                      var s = g.AddComponent<SpriteRenderer>();// Instantiate(inst.spriteTemplate) as SpriteRenderer;
                      s.transform.parent = inst.transform;// spriteTemplate.transform.parent;

                      //s.enabled = false;
                      return s;
                  },
                  Initialize = s =>
                  {
                      // "GIVE TEXT IN POOL".logError();

                      s.enabled = true;

                      s.color = Color.white;
                      s.flipX = false;
                      s.drawMode = SpriteDrawMode.Simple;
                      //s.material = vfx.vfxMaterials.spriteDefault;
                      s.maskInteraction = SpriteMaskInteraction.None;

                      s.transform.localScale = Vector3.one;
                      s.transform.eulerAngles = Vector3.zero;

                      //   s.myReset();
                      //   s.transform.myReset();

                      //   s.enabled = true;
                      //   s.transform.localScale = Vector3.one;
                      //   s.transform.eulerAngles = Vector3.zero;
                      //   s.color = Color.white;



                  },
                  Deactivate = s =>
                  {
                      //"RETURN TEXT IN POOL".logError();
                      s.enabled = false;
                  },
              };
        public static SpriteRenderer sprite()
        {
            return inst.spritePool.Get();
        }
        public static SpriteRenderer clone(SpriteRenderer eidolo)
        {
            var clone = inst.spritePool.Get();
            clone.cloneTo(eidolo);
            return clone;
        }
        public static void returnMe(SpriteRenderer s)
        {
            inst.spritePool.Remove(s);
        }

        #endregion


        #region  //// RIGID - SPRITE POOL OFF

        // foivosPool<(SpriteRenderer, Rigidbody2D)> rigidSpritePool { get; set; } =
        //         new()
        //         {
        //             Instantiate = () =>
        //             {
        //                 var g = new GameObject("rigid-sprite");
        //                 var s = g.AddComponent<SpriteRenderer>();
        //                 var r = g.AddComponent<Rigidbody2D>();

        //                 s.transform.parent = inst.transform;
        //                 //s.gameObject.SetActive(false);



        //                 return (s, r);
        //             },
        //             Initialize = item =>
        //             {
        //                 // "GIVE TEXT IN POOL".logError();

        //                 item.Item2.gameObject.SetActive(true);

        //                 item.Item1.myReset();
        //                 item.Item2.myReset();
        //                 item.Item2.transform.myReset();



        //             },
        //             Deactivate = item =>
        //             {
        //                 //"RETURN TEXT IN POOL".logError();
        //                 item.Item2.gameObject.SetActive(false);

        //             },
        //         };
        // public static (SpriteRenderer, Rigidbody2D) GetRigidSprite()
        // {
        //     return inst.rigidSpritePool.Get();
        // }
        // public static void ReturnRigidSprite((SpriteRenderer, Rigidbody2D) item)
        // {
        //     inst.rigidSpritePool.Remove(item);
        // }

        #endregion


        #region  ///// MASK POOL

        //[SerializeField] SpriteRenderer spriteTemplate;
        // foivosPool<SpriteMask> maskPool { get; set; } =
        //       new()
        //       {
        //           Instantiate = () =>
        //           {
        //               var g = new GameObject("mask");
        //               var m = g.AddComponent<SpriteMask>();// Instantiate(inst.spriteTemplate) as SpriteRenderer;
        //               m.transform.parent = inst.transform;// spriteTemplate.transform.parent;

        //               //s.enabled = false;
        //               return m;
        //           },
        //           Initialize = m =>
        //           {
        //               // "GIVE TEXT IN POOL".logError();

        //               //m.enabled = true;
        //               //m.myReset();
        //               m.transform.myReset();
        //               m.sprite = constants.square;
        //               m.gameObject.SetActive(true);

        //               //m.



        //           },
        //           Deactivate = m =>
        //           {
        //               //"RETURN TEXT IN POOL".logError();
        //               //m.enabled = false;
        //               m.gameObject.SetActive(false);
        //           },
        //       };
        // public static SpriteMask GetMask()
        // {
        //     return inst.maskPool.Get();
        // }
        // public static void ReturnMask(SpriteMask m)
        // {
        //     inst.maskPool.Remove(m);
        // }


        #endregion



        #region  ////2d light pool

        foivosPool<Light2D> lightPool { get; set; } =
              new()
              {
                  Instantiate = () =>
                  {
                      var g = new GameObject("light");
                      var l = g.AddComponent<Light2D>();
                      l.transform.parent = inst.transform;

                      return l;
                  },
                  Initialize = l =>
                  {
                      l.enabled = true;
                      l.intensity = 1;
                      l.transform.localScale = Vector3.one;
                      l.transform.eulerAngles = Vector3.zero;
                      l.lightType = Light2D.LightType.Point;
                  },
                  Deactivate = l =>
                  {
                      l.enabled = false;
                  },
              };
        public static Light2D GetLight()
        {
            return inst.lightPool.Get();
        }
        public static void ReturnLight(Light2D l)
        {
            inst.lightPool.Remove(l);
        }


        #endregion

    }
}