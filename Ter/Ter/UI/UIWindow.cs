using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ter.UI
{
    class UIWindow : UIBase
    {
        public const int TITLE_BAR_HEIGHT = 25;

        public bool IsVisibleTitleBar = true;                           //рисовать заголовочную часть окна?
        public Color BodyColor = new Color(80, 80, 80, 127);            //цвет заливки формы
        public Color TitleColor = new Color(60, 60, 60, 127);           //цвет заливки заголовочной части
        public Color TitleColorOver = new Color(60, 60, 60, 255);       //цвет заливки заголовочной части при наведении курсора мыши


        RectangleShape RectangleShapeTitleBar;

        public UIWindow()
        {
            rectShape = new RectangleShape(new Vector2f(400, 300));
            RectangleShapeTitleBar = new RectangleShape(new Vector2f(rectShape.Size.X, TITLE_BAR_HEIGHT));

            ApplyColors();
        }

        public void ApplyColors()
        {
            rectShape.FillColor = BodyColor;
            RectangleShapeTitleBar.FillColor = (UIMahager.Over == this || UIMahager.Drag == this) ? TitleColorOver : TitleColor;

            
        }

        public override void UpdateOver(Vector2i mousePos)
        {
            base.UpdateOver(mousePos);

            if (IsVisibleTitleBar)
            {
                var localMousePos = mousePos - GlobalPostin + GlobalOrigin;
                IsAllowDrag = UIMahager.Drag == this || RectangleShapeTitleBar.GetLocalBounds().Contains(localMousePos.X, localMousePos.Y);
            }
        }

        public override void Update()
        {
            base.Update();

            ApplyColors();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            states.Transform *= Transform;

            if (IsVisibleTitleBar)
                target.Draw(RectangleShapeTitleBar, states);
        }

        public override void OnCancelDrag()
        {
        }
    }
}
