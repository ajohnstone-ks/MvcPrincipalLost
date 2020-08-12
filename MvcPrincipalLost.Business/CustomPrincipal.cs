using System;

namespace MvcPrincipalLost.Business {
    [Serializable]
    public sealed class CustomPrincipal : Csla.Security.CslaPrincipal {
	    public static CustomPrincipal NewAsgardPrincipal() {
		    return new CustomPrincipal(new CustomIdentity());
	    }

	    public CustomPrincipal() : base(new CustomIdentity()) { }

	    private CustomPrincipal(CustomIdentity identity) : base(identity) { }
    }
}
