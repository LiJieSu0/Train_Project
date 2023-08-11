using CardScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardScene
{

    public class DragCard : MonoBehaviour
    {
        private Vector2 initPos;
        private Quaternion initRot;
        private bool isDragging = false;
        private Vector2 offset;
        private bool isInDropZone=false;
        private bool isDraggable = false;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isDragging&& isDraggable)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = mousePos + offset;
            }

        }
        private void OnMouseDown()
        {
            initPos = transform.position;
            initRot = transform.rotation;
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }


        private void OnMouseUp()
        {
            if (isDragging)
            {
                isDragging = false;

                // Check if the card is over the drop zone
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Enemy"))
                    {
                        //TODO play card
                        this.transform.parent = GameObject.Find(SceneManager.GRAVEYARD).transform;
                        this.gameObject.GetComponent<FlipCard>().flip();
                        toggleDraggable();
                        this.gameObject.transform.localPosition=new Vector3(0,0,0);
                        this.GetComponent<BaseCardObj>().PlayCard(collider.gameObject);

                        return;
                    }
                }

                // Card is not dropped in the drop zone, return to initial position
                transform.position = initPos;
                transform.rotation = initRot;
            }

        }

        public void toggleDraggable()
        {
            isDraggable = !isDraggable;
        }

}

}