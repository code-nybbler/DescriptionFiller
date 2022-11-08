using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Label = Microsoft.Xrm.Sdk.Label;

namespace DescriptionFiller
{
    public partial class DescriptionFillerControl : PluginControlBase
    {
        private Settings mySettings;
        private List<EntityMetadata> entities;
        private List<string> SelectedEntities;
        private List<string> SelectedComponents;
        private string EntityDescription;
        private string FormDescription;
        private string ViewDescription;
        private string FieldDescription;

        public DescriptionFillerControl()
        {
            InitializeComponent();
        }

        private void DescriptionFillerControl_Load(object sender, EventArgs e)
        {
            //txt_Tags.Text = "{table} - Injects singular table display name\n{form} - Injects form name\n{type} - Injects form type\n{view} - Injects view name\n{field} - Injects field name";
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void btn_LoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            DisableInputs();

            SelectedComponents = new List<string>();
            SelectedEntities = new List<string>();
            EntityDescription = txt_TableDesc.Text;
            FormDescription = txt_FormDesc.Text;
            ViewDescription = txt_ViewDesc.Text;
            FieldDescription = txt_FieldDesc.Text;

            foreach (string entity in lst_Entities.SelectedItems)
            {
                SelectedEntities.Add(entity);
            }

            if (chk_Entity.Checked == true)
            {
                SelectedComponents.Add(chk_Entity.Text);
            }

            if (chk_Forms.Checked == true)
                SelectedComponents.Add(chk_Forms.Text);

            if (chk_Views.Checked == true)
                SelectedComponents.Add(chk_Views.Text);

            if (chk_Fields.Checked == true)
                SelectedComponents.Add(chk_Fields.Text);

            ExecuteMethod(FillDescriptions);
        }

        private void DescriptionFillerControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void DisableInputs()
        {
            btn_LoadEntities.Enabled = false;
            btn_Execute.Enabled = false;

            lst_Entities.Enabled = false;

            chk_Entity.Enabled = false;
            chk_Forms.Enabled = false;
            chk_Views.Enabled = false;
            chk_Fields.Enabled = false;

            txt_TableDesc.Enabled = false;
            txt_FormDesc.Enabled = false;
            txt_ViewDesc.Enabled = false;
            txt_FieldDesc.Enabled = false;
        }

        private void EnableInputs()
        {
            btn_LoadEntities.Enabled = true;
            btn_Execute.Enabled = true;

            lst_Entities.Enabled = true;

            chk_Entity.Enabled = true;
            chk_Forms.Enabled = true;
            chk_Views.Enabled = true;
            chk_Fields.Enabled = true;

            txt_TableDesc.Enabled = true;
            txt_FormDesc.Enabled = true;
            txt_ViewDesc.Enabled = true;
            txt_FieldDesc.Enabled = true;
        }

        private void FillDescriptions()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Filling descriptions...",
                Work = (w, e2) =>
                {
                    // This code is executed in another thread
                    EntityMetadata entity;
                    foreach (string ent in SelectedEntities)
                    {
                        entity = entities.Find(x => x.LogicalName == ent.ToString());
                        UpdateEntityComponentDescriptions(entity);
                    }

                    w.ReportProgress(-1, "Descriptions filled.");
                    e2.Result = 1;
                },
                ProgressChanged = e2 =>
                {
                    SetWorkingMessage(e2.UserState.ToString());
                },
                PostWorkCallBack = e2 =>
                {
                    // This code is executed in the main thread
                    PublishEntities();
                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private List<EntityMetadata> GetAllEntityMetadata()
        {
            var request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.All
            };

            var response = (RetrieveAllEntitiesResponse)Service.Execute(request);
            return response.EntityMetadata.ToList();
        }

        private void LoadEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving entities...",
                Work = (w, e) =>
                {
                    // This code is executed in another thread
                    entities = GetAllEntityMetadata();

                    w.ReportProgress(-1, "Entities loaded.");
                    e.Result = 1;
                },
                ProgressChanged = e =>
                {
                    SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {
                    // This code is executed in the main thread
                    foreach (var entity in entities)
                    {
                        lst_Entities.Items.Add(entity.LogicalName);
                    }
                    EnableInputs();
                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void PublishEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Publishing entities...",
                Work = (w, e) =>
                {
                    // This code is executed in another thread
                    // publish selected entities
                    PublishXmlRequest publishEntityRequest = new PublishXmlRequest
                    {
                        ParameterXml = "<importexportxml><entities><entity>" + string.Join("</entity><entity>", SelectedEntities.ToArray()) + "</entity></entities></importexportxml>"
                    };

                    Service.Execute(publishEntityRequest);

                    w.ReportProgress(-1, "Publishing complete.");
                    e.Result = 1;
                },
                ProgressChanged = e =>
                {
                    SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {
                    // This code is executed in the main thread
                    EnableInputs();
                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });

        }

        private void UpdateEntityComponentDescriptions(EntityMetadata entity)
        {
            if (SelectedComponents.Contains("Entity"))
            {
                EntityDescription = EntityDescription.Replace("{table}", entity.DisplayName.UserLocalizedLabel.Label.ToString());
                UpdateEntityDescription(entity);
            }

            if (SelectedComponents.Contains("Forms"))
            {
                FormDescription = FormDescription.Replace("{table}", entity.DisplayName.UserLocalizedLabel.Label.ToString());
                UpdateFormDescriptions(entity);
            }

            if (SelectedComponents.Contains("Views"))
            {
                ViewDescription = ViewDescription.Replace("{table}", entity.DisplayName.UserLocalizedLabel.Label.ToString());
                UpdateViewDescriptions(entity);
            }

            if (SelectedComponents.Contains("Fields"))
            {
                FieldDescription = FieldDescription.Replace("{table}", entity.DisplayName.UserLocalizedLabel.Label.ToString());
                UpdateFieldDescriptions(entity);
            }
        }

        private void UpdateEntityDescription(EntityMetadata entity)
        {
            try
            {
                entity.Description = new Label(EntityDescription, 1033);

                UpdateEntityRequest updateRequest = new UpdateEntityRequest
                {
                    Entity = entity
                };

                Service.Execute(updateRequest);

                // Retrieve the entity to verify
                RetrieveEntityRequest retrieveRequest = new RetrieveEntityRequest
                {
                    EntityFilters = EntityFilters.Entity,
                    LogicalName = entity.LogicalName,
                    RetrieveAsIfPublished = true
                };

                RetrieveEntityResponse retrieveResponse = (RetrieveEntityResponse)Service.Execute(retrieveRequest);

                if (retrieveResponse.EntityMetadata.Description.UserLocalizedLabel.Label != EntityDescription)
                {
                    MessageBox.Show($"Description failed to update for {entity.DisplayName.UserLocalizedLabel.Label}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Desciption update failed. Please reference exception: {ex.Message}.");
            }
        }

        private void UpdateFormDescriptions(EntityMetadata entity)
        {
            try
            {
                QueryExpression q = new QueryExpression("systemform")
                {
                    ColumnSet = new ColumnSet("name", "description", "type")
                };
                q.Criteria.AddCondition(new ConditionExpression("objecttypecode", ConditionOperator.Equal, entity.LogicalName));

                EntityCollection forms = Service.RetrieveMultiple(q);

                string desc;
                foreach (Entity form in forms.Entities)
                {
                    desc = FormDescription.Replace("{form}", form["name"].ToString()).Replace("{type}", form.FormattedValues["type"].ToString()).Replace("Quick View Form", "Quick View");
                    form["description"] = desc;
                    Service.Update(form);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Desciption update failed. Please reference exception: {ex.Message}.");
            }
        }

        private void UpdateViewDescriptions(EntityMetadata entity)
        {
            try
            {
                QueryExpression q = new QueryExpression("savedquery")
                {
                    ColumnSet = new ColumnSet("name", "description")
                };
                q.Criteria.AddCondition(new ConditionExpression("querytype", ConditionOperator.Equal, 0));
                q.Criteria.AddCondition(new ConditionExpression("returnedtypecode", ConditionOperator.Equal, entity.ObjectTypeCode));

                EntityCollection views = Service.RetrieveMultiple(q);

                string desc;
                foreach (Entity view in views.Entities)
                {
                    desc = ViewDescription.Replace("{view}", view["name"].ToString());
                    view["description"] = desc;
                    Service.Update(view);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Desciption update failed. Please reference exception: {ex.Message}.");
            }
        }

        private void UpdateFieldDescriptions(EntityMetadata entity)
        {
            try
            {
                UpdateAttributeRequest updateRequest;

                string desc;
                foreach (AttributeMetadata attr in entity.Attributes)
                {
                    desc = FieldDescription;//.Replace("{field}", attr.DisplayName.UserLocalizedLabel.Label.ToString());
                    attr.Description = new Label(desc, 1033);

                    updateRequest = new UpdateAttributeRequest
                    {
                        EntityName = entity.LogicalName,
                        Attribute = attr
                    };

                    Service.Execute(updateRequest);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Desciption update failed. Please reference exception: {ex.Message}.");
            }
        }
    }
}