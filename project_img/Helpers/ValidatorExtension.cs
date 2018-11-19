using System;
using System.Collections.Generic;
using MvvmValidation;

namespace project_img.Helpers
{
    public static class ValidatorExtension
    {
        public static void AddErrors(this ValidationHelper validator, string target, List<string> errors)
        {
            errors?.ForEach(it =>
            {
                validator.AddRule(target, () => RuleResult.Invalid($"{target}: {it}"));
            });
        }
    }
}
