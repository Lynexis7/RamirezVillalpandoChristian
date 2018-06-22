// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface IngresoViewController : UIViewController {
	UIButton *_btnCancelar;
	UIButton *_btnGuardarIngreso;
	UITextField *_txtDescripcion;
	UITextField *_txtMonto;
}

@property (nonatomic, retain) IBOutlet UIButton *btnCancelar;
@property (weak, nonatomic) IBOutlet UIButton *btnGuardarIngreso;
- (IBAction)btnGuardar:(id)sender;


@property (nonatomic, retain) IBOutlet UITextField *txtDescripcion;

@property (nonatomic, retain) IBOutlet UITextField *txtMonto;

@end
