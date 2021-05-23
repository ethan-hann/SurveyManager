using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyManager.utility.CustomControls
{
    public partial class CRichTextBox : UserControl
    {
        public string RTFText
        {
            get
            {
                return rtbContent.Rtf;
            }
            set
            {
                rtbContent.Rtf = value;
            }
        }

        public CRichTextBox()
        {
            InitializeComponent();
        }

        private void CRichTextBox_Load(object sender, EventArgs e)
        {
            rtbContent.Font = new Font(FontFamily.GenericSansSerif, 14);
            rtbContent.Focus();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (!(rtbContent.SelectionFont == null))
            {
                fontDialog1.Font = rtbContent.SelectionFont;
            }
            else
            {
                fontDialog1.Font = null;
            }

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbContent.SelectionFont = fontDialog1.Font;
            }
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = rtbContent.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbContent.SelectionColor = colorDialog1.Color;
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font new1, old1;
                old1 = rtbContent.SelectionFont;
                if (old1.Bold)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Bold);

                rtbContent.SelectionFont = new1;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font new1, old1;
                old1 = rtbContent.SelectionFont;
                if (old1.Italic)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Italic);

                rtbContent.SelectionFont = new1;
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font new1, old1;
                old1 = rtbContent.SelectionFont;
                if (old1.Underline)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Underline);

                rtbContent.SelectionFont = new1;
            }
        }

        private void btnStrikeT_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font new1, old1;
                old1 = rtbContent.SelectionFont;
                if (old1.Strikeout)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Strikeout);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Strikeout);

                rtbContent.SelectionFont = new1;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (rtbContent.CanUndo)
            {
                rtbContent.Undo();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (rtbContent.CanRedo)
            {
                rtbContent.Redo();
            }
        }

        private void btnAlignLeft_Click(object sender, EventArgs e)
        {
            rtbContent.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        }

        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            rtbContent.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
        }

        private void btnAlignRight_Click(object sender, EventArgs e)
        {
            rtbContent.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right;
        }

        private void btnBulletList_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionBullet)
            {
                rtbContent.SelectionBullet = false;
            }
            else
            {
                rtbContent.BulletIndent = 10;
                rtbContent.SelectionBullet = true;
            }
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            rtbContent.Cut();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            rtbContent.Copy();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            rtbContent.Paste();
        }

        private void btnSubScript_Click(object sender, EventArgs e)
        {
            if (!(rtbContent.SelectionFont == null))
            {
                Font current = rtbContent.SelectionFont;
                float newSize = 0.75f * current.Size;
                rtbContent.SelectionFont = new Font(current.FontFamily, newSize, current.Style);
                rtbContent.SelectionCharOffset = rtbContent.SelectionCharOffset < 0 ? 0 : -10;
            }

        }

        private void btnSuperScript_Click(object sender, EventArgs e)
        {
            if (!(rtbContent.SelectionFont == null))
            {
                Font current = rtbContent.SelectionFont;
                float newSize = 0.75f * current.Size;
                rtbContent.SelectionFont = new Font(current.FontFamily, newSize, current.Style);
                rtbContent.SelectionCharOffset = rtbContent.SelectionCharOffset > 0 ? 0 : 10;
            }
        }
    }
}
