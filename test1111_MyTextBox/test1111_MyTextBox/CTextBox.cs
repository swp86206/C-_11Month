using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1111_MyTextBox
{

    [ToolboxBitmap(typeof(TextBox))] // TextBox 的描述性資訊

    public class CTextBox : TextBox

    {
        ////預設屬性值
        //public void ....

        public bool SupportUpDown { get; set; }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            
            base.OnKeyDown(e);

            if (this.SupportUpDown)
            { 
            // 上下鍵可以作 tab 切換功能
            switch (e.KeyCode)
                {
                    case Keys.Up:
                        SendKeys.Send("+{Tab}");
                        break;
                    case Keys.Down:
                        SendKeys.Send("{Tab}");
                        break;
                }
            }
        }


    }
}
