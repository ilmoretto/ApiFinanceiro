using Microsoft.AspNetCore.Mvc;

namespace ApiFinanceiro.Exceptions
{
    public class ErrorServiceExcepion : Exception
    {
        private readonly Func<ControllerBase, IActionResult> _result;

        public ErrorServiceExcepion(string message, Func<ControllerBase, IActionResult> result) : base(message)
        {
            _result = result;
        }

        public IActionResult ToAcationResult(ControllerBase controller)
        {
                       return _result(controller);
        }
    }
}
