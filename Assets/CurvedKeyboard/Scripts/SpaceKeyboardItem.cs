using UnityEngine;

namespace HoloLensKeyboard
{

    public class SpaceKeyboardItem : KeyboardItem
    {
        private SpaceMeshCreator meshCreator;
        private Renderer quadFront;
        private const string QUAD_FRONT = "Front";

        public void BuildMesh(KeyboardCreator creator, Sprite spaceSprite)
        {
            if(meshCreator == null)
            {
                meshCreator = new SpaceMeshCreator(creator);
            }

            if(quadFront == null)
            {
                quadFront = transform.Find(QUAD_FRONT).GetComponent<Renderer>();
            }
            meshCreator.BuildFace(quadFront, true);
        }
    }
}

