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
	[Register ("IngresoViewController")]
	partial class IngresoViewController
	{
		[Outlet]
		UIKit.UIButton btnCancelar { get; set; }

		[Outlet]
		UIKit.UIButton btnGuardarIngreso { get; set; }

		[Outlet]
		UIKit.UITextField txtDescripcion { get; set; }

		[Outlet]
		UIKit.UITextField txtMonto { get; set; }

		[Action ("btnGuardar:")]
		partial void btnGuardar (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCancelar != null) {
				btnCancelar.Dispose ();
				btnCancelar = null;
			}

			if (btnGuardarIngreso != null) {
				btnGuardarIngreso.Dispose ();
				btnGuardarIngreso = null;
			}

			if (txtDescripcion != null) {
				txtDescripcion.Dispose ();
				txtDescripcion = null;
			}

			if (txtMonto != null) {
				txtMonto.Dispose ();
				txtMonto = null;
			}
		}
	}
}
