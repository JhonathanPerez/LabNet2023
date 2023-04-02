import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SpinnerComponent } from './spinner/spinner.component';
import { MaterialModule } from '../material/material.module';
import { ErrorModalComponent } from './error-modal/error-modal.component';

@NgModule({
  declarations: [SpinnerComponent, ErrorModalComponent],
  imports: [CommonModule, MaterialModule],
  exports: [SpinnerComponent, ErrorModalComponent],
})
export class SharedModule {}
