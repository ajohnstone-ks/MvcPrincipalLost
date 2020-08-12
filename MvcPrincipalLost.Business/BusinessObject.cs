using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Csla;
using Csla.Security;

namespace MvcPrincipalLost.Business {
	[Serializable]
	public sealed class BusinessObject : BusinessBase<BusinessObject> {
		public static readonly PropertyInfo<Guid> IdProperty = RegisterProperty<Guid>(x => x.Id);
		public Guid Id {
			get => GetProperty(IdProperty);
			private set => LoadProperty(IdProperty, value);

		}

		public static readonly PropertyInfo<string> NameProperty = RegisterProperty(x => x.Name, "Name", "");
		[Required]
		public string Name {
			get => GetProperty(NameProperty);
			set => SetProperty(NameProperty, value);
		}

		public static readonly PropertyInfo<bool> WasSavedProperty = RegisterProperty<bool>(x => x.WasSaved);
		public bool WasSaved {
			get => GetProperty(WasSavedProperty);
			private set => LoadProperty(WasSavedProperty, value);
		}

		public static Task<BusinessObject> Get(Guid id) => DataPortal.FetchAsync<BusinessObject>(id);

		private void DataPortal_Fetch(Guid id)
		{
			var customerPrincipal = Csla.ApplicationContext.User as CustomPrincipal;
			if (customerPrincipal == null)
			{
				throw new SecurityException();
			}

			Id = id;

			BusinessRules.CheckRules();
		}

		private new Task DataPortal_Update()
		{
			WasSaved = true;

			return Task.CompletedTask;
		}
	}
}