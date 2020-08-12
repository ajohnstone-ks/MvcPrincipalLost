using System;
using System.Security.Principal;
using Csla;

namespace MvcPrincipalLost.Business {
	[Serializable]
	public sealed class CustomIdentity : ReadOnlyBase<CustomIdentity>, IIdentity {
		public string Name { get; } = "Custom Identity";
		public string AuthenticationType { get; } = "Custom Identity";
		public bool IsAuthenticated { get; } = true;
	}
}
