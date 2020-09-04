using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Ter.UI
{
    abstract class UIBase : Transformable, Drawable
    {
        public UIBase oldParent = null;     //предыдущый родитель до перетаскивания элемента
        public UIBase Parent = null;        //родитель

        public new Vector2i Position
        {
            get { return (Vector2i)base.Position; }
            set { base.Position = (Vector2f)value; }
        }
        public new Vector2i Origin
        {
            get { return (Vector2i)base.Origin; }
            set { base.Origin = (Vector2f)value; }
        }

        public Vector2i GlobalPostin
        {
            get
            {
                if (Parent == null)
                    return Position;
                else
                    return Parent.GlobalPostin;
            }
        }
        public Vector2i GlobalOrigin
        {
            get
            {
                if (Parent == null)
                    return Origin;
                else
                    return Parent.GlobalOrigin;
            }
        }

        public int Width
        {
            get { return (int)rectShape.Size.X; }
            set { rectShape.Size = new Vector2f(value, rectShape.Size.Y); }
        }

        public int Height
        {
            get { return (int)rectShape.Size.Y; }
            set { rectShape.Size = new Vector2f(rectShape.Size.X, value); }
        }

        public Vector2i Size
        {
            get { return (Vector2i)rectShape.Size; }
            set { rectShape.Size = (Vector2f)value; }
        }

        public bool IsAllowDrag = false; //Разрешено перетаскивать UI мышью?
        public Vector2i DragOffset { get; private set; }

        protected RectangleShape rectShape;

        public virtual void UpdateOver(Vector2i mousePos)
        {
            var localMousePos = mousePos - GlobalPostin + GlobalOrigin;

            if (rectShape.GetGlobalBounds().Contains(localMousePos.X, localMousePos.Y))
            {
                if (UIMahager.Drag == null)
                {
                    if (IsAllowDrag && Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        UIMahager.Drag = this;
                        DragOffset = mousePos - GlobalPostin;
                        OnDragBegin();
                    }
                }

                if (UIMahager.Drag != this)
                    UIMahager.Over = this;
            }
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rectShape, states);
        }

        //когда текущий элемент начинают тащить мышкой
        public virtual void OnDragBegin()
        {
            oldParent = Parent;

            Parent = null;
        }

        //когда на текущий элемент сбрасывают другой
        public virtual void OnDrop(UIBase ui)
        {

        }

        //когда невозможно сбросить текущий элемент куда то и нужно отменить все изменения
        public virtual void OnCancelDrag()
        {
            Parent = oldParent;
            Position = new Vector2i();
        }
    }
}
