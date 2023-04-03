import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SpinnerComponent } from './components/spinner/spinner.component';
import { MaterialModule } from '../material/material.module';
import { ErrorModalComponent } from './components/error-modal/error-modal.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ToastService, AngularToastifyModule } from 'angular-toastify';

@NgModule({
  declarations: [SpinnerComponent, ErrorModalComponent, NavbarComponent],
  imports: [CommonModule, MaterialModule, AngularToastifyModule],
  exports: [SpinnerComponent, ErrorModalComponent, NavbarComponent],
  providers: [ToastService],
})
export class SharedModule {}
