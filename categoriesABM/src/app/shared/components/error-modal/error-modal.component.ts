import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-error-modal',
  templateUrl: './error-modal.component.html',
  styleUrls: ['./error-modal.component.css'],
})
export class ErrorModalComponent {
  errorMessage!: string;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<ErrorModalComponent>
  ) {
    this.errorMessage = data.errorMessage || 'Error desconocido';
  }

  onDismiss(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {}
}
