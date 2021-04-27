using SSPKeyGen;
using Standard.Licensing;
using Standard.Licensing.Validation;
using SurveyManager.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace SurveyManager.utility.Licensing
{
    public class LicenseEngine
    {
        /// <summary>
        /// Checks a license against the public key and against the expiration date if a trial.
        /// </summary>
        /// <param name="l">The license object to check.</param>
        /// <returns>A string of validation messages and solutions to resolve, or <see cref="string.Empty"/> if the validation passed.</returns>
        public static string Validate(License l)
        {
            if (l.Id.Equals(HardwareInfo.GenerateUID("SurveyManagerApplication")))
            {
                IEnumerable<IValidationFailure> validationFailures = l.Validate().ExpirationDate().When(lic => lic.Type == Standard.Licensing.LicenseType.Trial).And()
                            .Signature(Resources.public_key)
                            .AssertValidLicense();

                StringBuilder builder = new StringBuilder();
                List<IValidationFailure> failures = validationFailures.ToList();
                if (failures.Count > 0)
                {
                    foreach (IValidationFailure failure in failures)
                    {
                        if (failure.GetType() == typeof(GeneralValidationFailure))
                        {
                            failure.Message = "The license file provided was invalid. Either the signature was corrupt (due to editing) or it was never valid to begin with.";
                            failure.HowToResolve = "Please purchase a new license file or select a different one.";
                        }
                        else if (failure.GetType() == typeof(InvalidSignatureValidationFailure))
                        {
                            failure.Message = "The license file's signature was corrupted. This is likely from attempts to edit it.";
                            failure.HowToResolve = "Either undo any edits to the file or purchase a new license file.";
                        }
                        else if (failure.GetType() == typeof(LicenseExpiredValidationFailure))
                        {
                            failure.Message = "The license file provided has expired.";
                            failure.HowToResolve = "Please purchase a new license file or select a different one.";
                        }

                        builder.Append($"{failure.Message} {failure.HowToResolve}\n");
                    }
                    return builder.ToString();
                }
                return string.Empty;
            }
            else
            {
                List<IValidationFailure> failues = new List<IValidationFailure>
                {
                    new InvalidProductKeyValidationFailure()
                };
                return $"{failues[0].Message} {failues[0].HowToResolve}";
            }
        }

        public static bool LoadLicense(string path)
        {
            string contents;
            try
            {
                contents = File.ReadAllText(path);
            }
            catch
            {
                return false;
            }

            RuntimeVars.Instance.CurrentLicense = License.Load(contents);
            if (RuntimeVars.Instance.CurrentLicense != null)
            {
                Settings.Default.LicenseFilePath = path;
                Settings.Default.Save();
            }

            return RuntimeVars.Instance.CurrentLicense != null;
        }
    }
}
