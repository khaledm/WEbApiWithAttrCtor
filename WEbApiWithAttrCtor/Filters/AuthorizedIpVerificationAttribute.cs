using System;
using System.ComponentModel;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using WEbApiWithAttrCtor.Services;

namespace WEbApiWithAttrCtor.Filters
{
    public class AuthorizedIpVerificationAttribute : AuthorizeAttribute
    {
        private readonly IVerifyIpAddress _ipAddressVerificationService;

        public AuthorizedIpVerificationAttribute(IVerifyIpAddress ipAddressVerificationService)
        {
            _ipAddressVerificationService = ipAddressVerificationService;
        }

        // Hide users and roles, since we aren't using them.
        [Obsolete("Not applicable in this class.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string Roles { get; set; }

        [Obsolete("Not applicable in this class.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new string Users { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return _ipAddressVerificationService.IsValidIpAddress(actionContext.Request);
        }
    }
}