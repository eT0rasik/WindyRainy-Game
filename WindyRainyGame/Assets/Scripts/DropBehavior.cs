using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ilya
{
    public class DropBehavior : MonoBehaviour
    {

        [SerializeField] private bool[] activated;
        private int aId;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerable Processing()
        {
            yield return new WaitForSeconds(0.03f);
            Debug.Log("Activated for Id " + aId + " Setted");
            activated[aId] = true;
        }
        IEnumerator TimeBeforeDestroing()
        {
            yield return new WaitForSeconds(0.04f);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "cloud")
            {
                var cloudIdSystem = collision.gameObject.GetComponent<IDSystem>();
                aId = cloudIdSystem.GetId();
                CloudMultiplier cloudMultiplier;
                if (collision.gameObject.TryGetComponent<CloudMultiplier>(out cloudMultiplier))
                {

                    if (!activated[aId])
                    {
                        collision.gameObject.GetComponent<Animator>().SetTrigger("React");
                        activated[aId] = true;
                        cloudMultiplier.Spawn(gameObject);
                        //               StartCoroutine("Processing");
                        //               StartCoroutine("TimeBeforeDestroing");
                    }
                }
                else
                {
                    UnknownCloud unknownCloud;
                    if (collision.gameObject.TryGetComponent<UnknownCloud>(out unknownCloud))
                    {
                        // var unknownCloud = collision.gameObject.GetComponent<UnknownCloud>(); 
                        if (!activated[aId])
                        {
                            collision.gameObject.GetComponent<Animator>().SetTrigger("React");

                            activated[aId] = true;
                            unknownCloud.Spawn(gameObject);
                            //               StartCoroutine("Processing");
                            //               StartCoroutine("TimeBeforeDestroing");
                        }
                    }
                    else
                    {
                        var randomCloud = collision.gameObject.GetComponent<RandomCloud>();
                        {
                            if (!activated[aId])
                            {
                        collision.gameObject.GetComponent<Animator>().SetTrigger("React");

                                activated[aId] = true;
                                randomCloud.Spawn(gameObject);
                                //               StartCoroutine("Processing");
                                //               StartCoroutine("TimeBeforeDestroing");
                            }
                        }
                    }
                }
                //var cloudMultScript = collision.gameObject.GetComponent<CloudMultiplier>();
            }

                
        }

        public void SetActivated(bool[] activ)
        {
            activated = activ;
        }

        public bool isActivated(int id)
        {
            return activated[id];
        }
    }
}