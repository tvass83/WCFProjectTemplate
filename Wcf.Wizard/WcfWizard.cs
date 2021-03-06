﻿using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Wcf.Wizard
{
    public class WcfWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {

        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {

        }

        public void RunFinished()
        {

        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                var dialog = new WizardForm();
                dialog.ShowDialog();

                // Ignore DialogResult

                string sc = dialog.Wizard_ServiceContract;

                if (string.IsNullOrWhiteSpace(sc))
                {
                    sc = "IPingService";
                }

                replacementsDictionary[$"${nameof(WizardForm.Wizard_ServiceContract)}$"] = sc;

                string scImpl = dialog.Wizard_ServiceImplClass;

                if (string.IsNullOrWhiteSpace(scImpl))
                {
                    scImpl = "PingService";
                }

                replacementsDictionary.Add($"${nameof(WizardForm.Wizard_ServiceImplClass)}$", scImpl);

                string cbc = dialog.Wizard_CallbackContract;

                if (string.IsNullOrWhiteSpace(cbc))
                {
                    cbc = "IPingServiceCallback";
                }

                replacementsDictionary.Add($"${nameof(WizardForm.Wizard_CallbackContract)}$", cbc);

                string cbcImpl = dialog.Wizard_CallbackImplClass;

                if (string.IsNullOrWhiteSpace(cbcImpl))
                {
                    cbcImpl = "PingServiceCallback";
                }

                replacementsDictionary.Add($"${nameof(WizardForm.Wizard_CallbackImplClass)}$", cbcImpl);

                replacementsDictionary.Add($"${nameof(WizardForm.Wizard_IsRestService)}$", dialog.Wizard_IsRestService.ToString());
                replacementsDictionary.Add($"${nameof(WizardForm.Wizard_IsDuplexService)}$", dialog.Wizard_IsDuplexService.ToString());

                // As the evaluation of nested conditions seem to be buggy, combine the flags to flatten the event space
                bool Wizard_RestOnDuplexOff = dialog.Wizard_IsRestService && !dialog.Wizard_IsDuplexService;
                bool Wizard_RestOffDuplexOff = !dialog.Wizard_IsRestService && !dialog.Wizard_IsDuplexService;
                bool Wizard_RestOffDuplexOn = !dialog.Wizard_IsRestService && dialog.Wizard_IsDuplexService;

                replacementsDictionary.Add($"${nameof(Wizard_RestOnDuplexOff)}$", Wizard_RestOnDuplexOff.ToString());
                replacementsDictionary.Add($"${nameof(Wizard_RestOffDuplexOff)}$", Wizard_RestOffDuplexOff.ToString());
                replacementsDictionary.Add($"${nameof(Wizard_RestOffDuplexOn)}$", Wizard_RestOffDuplexOn.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
