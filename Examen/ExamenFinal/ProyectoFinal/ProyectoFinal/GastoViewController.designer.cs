// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ProyectoFinal
{
	[Register ("GastoViewController")]
	partial class GastoViewController
	{
		[Outlet]
		UIKit.UIButton btnCancelar { get; set; }

		[Outlet]
		UIKit.UIButton btnGuardarGasto { get; set; }

		[Outlet]
		UIKit.UITextField txtDescripcion { get; set; }

		[Outlet]
		UIKit.UITextField txtMonto { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtMonto != null) {
				txtMonto.Dispose ();
				txtMonto = null;
			}

			if (btnGuardarGasto != null) {
				btnGuardarGasto.Dispose ();
				btnGuardarGasto = null;
			}

			if (btnCancelar != null) {
				btnCancelar.Dispose ();
				btnCancelar = null;
			}

			if (txtDescripcion != null) {
				txtDescripcion.Dispose ();
				txtDescripcion = null;
			}
		}
	}
}
