using System;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace MaximovInk.UI
{
    [Flags]
    public enum Corners
    {
        None = 0,
        LeftTop = 1,
        RightTop = 2,
        LeftBottom = 4,
        RightBottom = 8
    }

    public class RoundedPanel : MaskableGraphic
    {
        public Corners InnerCorners;
        public Corners OuterCorners;
        public int Segments = 5;
        public float BorderWidth = 5f;
        public float InnerBorderWidth = 5f;

        public bool OverrideBorderColor = false;
        public Color BorderColor = Color.white;

        public bool RelativeSize = false;


        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            var min = new Vector2(0, 0) - rectTransform.pivot;
            min.x *= rectTransform.rect.width;
            min.y *= rectTransform.rect.height;

            var size = rectTransform.rect.size;
            var max = min + size;

            if (BorderWidth <= 0)
            {
                AddQuad(vh,
                    min,
                    max,
                    color
                    );

                return;
            }
            var newBorderColor = OverrideBorderColor ? BorderColor : color;

            var minSize = Mathf.Min(rectTransform.rect.width / 2, rectTransform.rect.height / 2);

            var localBorderW = Mathf.Min(BorderWidth, minSize);
            var localInnerBorderW = Mathf.Min(InnerBorderWidth, minSize);

            if (RelativeSize)
            {
                localBorderW = BorderWidth / 100f * minSize;
                localInnerBorderW = InnerBorderWidth / 100f * minSize;
            }

            localInnerBorderW = Mathf.Clamp(localInnerBorderW, 0, minSize - localBorderW);

            var x0 = min.x;
            var x1 = x0 + localBorderW;
            var x2 = max.x - localBorderW;
            var x3 = max.x;

            var y0 = min.y;
            var y1 = y0 + localBorderW;
            var y2 = max.y - localBorderW;
            var y3 = max.y;

            //Outer corners
            if ((OuterCorners & Corners.LeftBottom) != 0)
                AddCorner(vh, new Vector2(x1, y1), new Vector2(x0, y0), newBorderColor);
            else
                AddQuad(vh, new Vector2(x1, y1), new Vector2(x0, y0), newBorderColor);

            if ((OuterCorners & Corners.RightBottom) == Corners.RightBottom)
                AddCorner(vh, new Vector2(x2, y1), new Vector2(x3, y0), newBorderColor, true);
            else
                AddQuad(vh, new Vector2(x2, y1), new Vector2(x3, y0), newBorderColor);

            if ((OuterCorners & Corners.LeftTop) != 0)
                AddCorner(vh, new Vector2(x1, y2), new Vector2(x0, y3), newBorderColor, true);
            else
                AddQuad(vh, new Vector2(x1, y2), new Vector2(x0, y3), newBorderColor);

            if ((OuterCorners & Corners.RightTop) == Corners.RightTop)
                AddCorner(vh, new Vector2(x2, y2), new Vector2(x3, y3), newBorderColor);
            else
                AddQuad(vh, new Vector2(x2, y2), new Vector2(x3, y3), newBorderColor);

            if (InnerCorners == Corners.None)
            {
                //Fill plane
                AddQuad(vh, new Vector2(x1, y1), new Vector2(x2, y2), color);
            }
            else
            {
                //Fill plane
                AddQuad(vh, new Vector2(x1 + localInnerBorderW, y1 + localInnerBorderW), new Vector2(x2 - localInnerBorderW, y2 - localInnerBorderW), color);

                //Inner borders

                AddQuad(vh, new Vector2(x1, y1 + localInnerBorderW), new Vector2(x1 + localInnerBorderW, y2 - localInnerBorderW), color);

                AddQuad(vh, new Vector2(x2 - localInnerBorderW, y1 + localInnerBorderW), new Vector2(x2, y2 - localInnerBorderW), color);

                AddQuad(vh, new Vector2(x1 + localInnerBorderW, y2 - localInnerBorderW), new Vector2(x2 - localInnerBorderW, y2), color);

                AddQuad(vh, new Vector2(x1 + localInnerBorderW, y1), new Vector2(x2 - localInnerBorderW, y1 + localInnerBorderW), color);

                //Inner corners
                if ((InnerCorners & Corners.RightTop) == Corners.RightTop)
                {
                    AddInnerCorner(vh, new Vector2(x2, y2), new Vector2(x2 - localInnerBorderW, y2 - localInnerBorderW), newBorderColor, true);
                    AddCorner(vh, new Vector2(x2 - localInnerBorderW, y2 - localInnerBorderW), new Vector2(x2, y2), color);
                }
                else
                {
                    AddQuad(vh, new Vector2(x2, y2), new Vector2(x2 - localInnerBorderW, y2 - localInnerBorderW), color);
                }

                if ((InnerCorners & Corners.RightBottom) == Corners.RightBottom)
                {
                    AddInnerCorner(vh, new Vector2(x2, y1), new Vector2(x2 - localInnerBorderW, y1 + localInnerBorderW), newBorderColor);
                    AddCorner(vh, new Vector2(x2 - localInnerBorderW, y1 + localInnerBorderW), new Vector2(x2, y1), color, true);
                }
                else
                {
                    AddQuad(vh, new Vector2(x2 - localInnerBorderW, y1), new Vector2(x2, y1 + localInnerBorderW), color);
                }

                if ((InnerCorners & Corners.LeftTop) == Corners.LeftTop)
                {
                    AddInnerCorner(vh, new Vector2(x1, y2), new Vector2(x1 + localInnerBorderW, y2 - localInnerBorderW), newBorderColor);
                    AddCorner(vh, new Vector2(x1 + localInnerBorderW, y2 - localInnerBorderW), new Vector2(x1, y2), color, true);
                }
                else
                {
                    AddQuad(vh, new Vector2(x1 + localInnerBorderW, y2), new Vector2(x1, y2 - localInnerBorderW), color);
                }

                if ((InnerCorners & Corners.LeftBottom) == Corners.LeftBottom)
                {
                    AddInnerCorner(vh, new Vector2(x1, y1), new Vector2(x1 + localInnerBorderW, y1 + localInnerBorderW), newBorderColor);
                    AddCorner(vh, new Vector2(x1 + localInnerBorderW, y1 + localInnerBorderW), new Vector2(x1, y1), color);
                }
                else
                {
                    AddQuad(vh, new Vector2(x1, y1), new Vector2(x1 + localInnerBorderW, y1 + localInnerBorderW), color);
                }
            }

            //Outer borders

            AddQuad(vh, new Vector2(x0, y1), new Vector2(x1, y2), newBorderColor);

            AddQuad(vh, new Vector2(x2, y1), new Vector2(x3, y2), newBorderColor);

            AddQuad(vh, new Vector2(x1, y2), new Vector2(x2, y3), newBorderColor);

            AddQuad(vh, new Vector2(x1, y0), new Vector2(x2, y1), newBorderColor);
        }

#if UNITY_EDITOR
        [MenuItem("GameObject/UI/Rounded panel")]
        private static void MakeThis(MenuCommand command)
        {
            var go = new GameObject("New Rounded panel");
            var panel = go.AddComponent<RoundedPanel>();
            go.AddComponent<CanvasRenderer>();

            panel.BorderWidth = 5;
            panel.Segments = 10;
            panel.OuterCorners = Corners.RightTop | Corners.RightBottom | Corners.LeftTop | Corners.LeftBottom;

            GameObjectUtility.SetParentAndAlign(go, command.context as GameObject);

            panel.SetAllDirty();

            Undo.RegisterCreatedObjectUndo(go, $"Create {go.name}");

            Selection.activeObject = go;
        }
#endif

        private static void AddQuad(VertexHelper vertexHelper, Vector2 posMin, Vector2 posMax, Color color)
        {
            var startIndex = vertexHelper.currentVertCount;

            vertexHelper.AddVert(new Vector3(posMin.x, posMin.y, 0), color, Vector2.zero);
            vertexHelper.AddVert(new Vector3(posMin.x, posMax.y, 0), color, Vector2.zero);
            vertexHelper.AddVert(new Vector3(posMax.x, posMax.y, 0), color, Vector2.zero);
            vertexHelper.AddVert(new Vector3(posMax.x, posMin.y, 0), color, Vector2.zero);

            vertexHelper.AddTriangle(startIndex, startIndex + 1, startIndex + 2);
            vertexHelper.AddTriangle(startIndex + 2, startIndex + 3, startIndex);
        }

        private static void AddTriangle(VertexHelper vertexHelper, Vector2 v1, Vector2 v2, Vector2 v3, Color color)
        {
            var startIndex = vertexHelper.currentVertCount;

            vertexHelper.AddVert(v1, color, Vector2.zero);
            vertexHelper.AddVert(v2, color, Vector2.zero);
            vertexHelper.AddVert(v3, color, Vector2.zero);

            vertexHelper.AddTriangle(startIndex, startIndex + 1, startIndex + 2);
        }

        private static Vector2 AngleToDirection(float angleDeg)
        {
            return new Vector2(Mathf.Sin(angleDeg * Mathf.Deg2Rad), Mathf.Cos(angleDeg * Mathf.Deg2Rad));
        }

        private void AddCorner(VertexHelper vh, Vector2 min, Vector2 max, Color color, bool invertTriangle = false)
        {
            var stepSize = 90f / Segments;

            var last = min;
            var delta = max - min;

            for (int i = 0; i < Segments + 1; i++)
            {
                var angle = stepSize * i;

                var dir = AngleToDirection(angle);

                var localDirX = min.x + (dir.x * delta.x);
                var localDirY = min.y + (dir.y * delta.y);

                var localDir = new Vector2(localDirX, localDirY);

                if (invertTriangle)
                    AddTriangle(vh, last, min, localDir, color);
                else
                    AddTriangle(vh, last, localDir, min, color);

                last = localDir;
            }
        }

        private void AddInnerCorner(VertexHelper vh, Vector2 min, Vector2 max, Color color, bool invertTriangle = false)
        {
            var stepSize = 90f / Segments;

            var last = min;
            var delta = max - min;

            for (int i = 0; i < Segments + 1; i++)
            {
                var angle = stepSize * i;

                var dir = AngleToDirection(angle);

                var localDirX = max.x - (dir.x * delta.x);
                var localDirY = max.y - (dir.y * delta.y);

                var localDir = new Vector2(localDirX, localDirY);

                if (invertTriangle)
                    AddTriangle(vh, last, min, localDir, color);
                else
                    AddTriangle(vh, last, localDir, min, color);

                last = localDir;
            }
        }
    }
}