using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.userControls
{
    public partial class NewObject : UserControl
    {
        private readonly EntityTypes entity;
        private DatabaseWrapper obj;

        public NewObject(EntityTypes entity, DatabaseWrapper o = null)
        {
            InitializeComponent();

            this.entity = entity;
            obj = o;

            if (obj == null)
            {
                switch (entity)
                {
                    case EntityTypes.Survey:
                        obj = new Survey();
                        break;
                    case EntityTypes.Client:
                        obj = new Client();
                        break;
                    case EntityTypes.Realtor:
                        obj = new Realtor();
                        break;
                    case EntityTypes.TitleCompany:
                        obj = new TitleCompany();
                        break;
                }
            }

            propGrid.GetAcceptButton().Click += SaveObject;
            propGrid.GetClearButton().Click += ClearObject;
            propGrid.GetAcceptButton().Visible = true;
            propGrid.GetClearButton().Visible = true;

            propGrid.SelectedObject = obj;
        }

        private void SaveObject(object sender, EventArgs e)
        {
            
        }

        private void ClearObject(object sender, EventArgs e)
        {
            
        }
    }
}
